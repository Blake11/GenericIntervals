using GenericIntervals.Core;
using GenericIntervals.Numbers;

namespace GenericIntervals.TimeSpanIntervals;

public readonly record struct TimespanIntervalDivider(
    TimeSpan Divider
) : IIntervalOperation<TimeSpanInterval, TimeSpan>
{
    public IEnumerable<TimeSpanInterval> Apply(TimeSpanInterval interval) 
        => Divide(interval);

    private IEnumerable<TimeSpanInterval> Divide(TimeSpanInterval interval)
    {
        var innerInterval = interval.AsTickInterval();
        var innerDivider = NumberIntervalDivider.Create<long, long>(Divider.Ticks);

        return innerDivider
            .Apply(innerInterval)
            .Select(x => TimeSpanInterval.FromTicks(x.Start, x.End));
    }

    
}