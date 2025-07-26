using GenericIntervals.Core;
using GenericIntervals.Numbers;

namespace GenericIntervals.DateTimeIntervals;

/// <summary>
/// Represents the Divide Operation on a DateTime Interval by using TimeSpan as the divider &#xA;
/// <para>Splits the interval into equally spaced DateTime Intervals</para>
/// <remarks>Last interval might be smaller than the rest due of interval not splitting evenly</remarks>
/// <exception cref="ArgumentOutOfRangeException">Interval, Start, End or Divider is null</exception>
/// </summary>
/// <param name="Divider">The Timespan used to evenly divide the interval</param>
public readonly record struct DateTimeTimespanIntervalDivider(
    TimeSpan Divider
) : IIntervalOperation<DateTimeInterval, DateTime>
{
    public IEnumerable<DateTimeInterval> Apply(DateTimeInterval interval)
        => Divide(interval);

    private IEnumerable<DateTimeInterval> Divide(DateTimeInterval interval)
    {
        var innerInterval = interval.AsTickInterval();
        var innerDivider = NumberIntervalDivider.Create<long, long>(Divider.Ticks);

        return innerDivider
            .Apply(innerInterval)
            .Select(x => DateTimeInterval.FromTicks(x.Start, x.End));
    }
}