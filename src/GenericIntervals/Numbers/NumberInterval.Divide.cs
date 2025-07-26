using System.Numerics;
using GenericIntervals.Core;

namespace GenericIntervals.Numbers;

public static class NumberIntervalDivider
{
    public static NumberIntervalDivider<TInUnit, TOutUnit> Create<TInUnit, TOutUnit>(TOutUnit divider)
        where TInUnit : INumber<TInUnit>
        where TOutUnit : INumber<TOutUnit>
        => new(divider);
}

/// <summary>
/// Represents the Divide Operation on a Number Interval by using Generic Math INumber as the divider
/// <para>Splits the interval into equally spaced Number Intervals</para>
/// </summary>
/// <remarks>Last interval might be smaller than the rest due of interval not splitting evenly</remarks>
/// <exception cref="ArgumentOutOfRangeException">Interval, Start, End or Divider is null</exception>
/// <param name="Divider">The number used to evenly divide the interval</param>
/// <typeparam name="TUnit">The type of number used for input interval</typeparam>
/// <typeparam name="TUnitDivider">the type of number that will divide the interval</typeparam>
public readonly record struct NumberIntervalDivider<TUnit, TUnitDivider>(
    TUnitDivider Divider
) : IIntervalOperation<NumberInterval<TUnit>, TUnit, NumberInterval<TUnitDivider>, TUnitDivider>
    where TUnit : INumber<TUnit>
    where TUnitDivider : INumber<TUnitDivider>
{
    public IEnumerable<NumberInterval<TUnitDivider>> Apply(NumberInterval<TUnit> interval)
        => Divide(interval);

    private IEnumerable<NumberInterval<TUnitDivider>> Divide(NumberInterval<TUnit> interval)
    {
        ArgumentNullException.ThrowIfNull(interval.Start);
        ArgumentNullException.ThrowIfNull(interval.End);
        ArgumentNullException.ThrowIfNull(Divider);

        var current = TUnitDivider.CreateChecked(interval.Start);
        var end = TUnitDivider.CreateChecked(interval.End);

        if (Divider == TUnitDivider.Zero)
        {
            yield return NumberInterval.Create(current, end);
            yield break;
        }

        var segmentLength = Divider;
        do
        {
            var s = current;
            current += segmentLength;
            var e = current;

            yield return NumberInterval.Create(s, e);
        } while (current < end);
    }
}