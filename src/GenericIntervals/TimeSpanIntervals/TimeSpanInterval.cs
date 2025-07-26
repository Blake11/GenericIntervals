using GenericIntervals.Core;
using GenericIntervals.Numbers;

namespace GenericIntervals.TimeSpanIntervals;

public readonly partial record struct TimeSpanInterval(
    TimeSpan Start,
    TimeSpan End
) : IInterval<TimeSpan>
{
    public bool IsEmpty() => Start == End;

    public NumberInterval<long> AsTickInterval()
        => NumberInterval.Create(Start.Ticks, End.Ticks);
}