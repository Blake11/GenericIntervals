using GenericIntervals.Core;
using GenericIntervals.Numbers;

namespace GenericIntervals.DateTimeIntervals;

/// <summary>
/// A DateTime Interval using NumberInterval&lt;long&gt; for operations
/// </summary>
/// <param name="Start">The start date of the interval</param>
/// <param name="End">The end date of the interval</param>
public readonly partial record struct DateTimeInterval(
    DateTime Start,
    DateTime End
) : IInterval<DateTime>
{
    public bool IsEmpty() => Start == End;

    /// <summary>
    /// Convert the interval into NumberInterval&lt;long&gt;
    /// </summary>
    /// <returns>The number interval equivalent in ticks</returns>
    public NumberInterval<long> AsTickInterval()
        => NumberInterval.Create(Start.Ticks, End.Ticks);
}