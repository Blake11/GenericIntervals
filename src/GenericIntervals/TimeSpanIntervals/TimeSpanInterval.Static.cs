namespace GenericIntervals.TimeSpanIntervals;

public partial record struct TimeSpanInterval
{
    public static TimeSpanInterval Create(TimeSpan start, TimeSpan end)
        => new(start, end);
    
    public static TimeSpanInterval FromTicks(long start, long end)
        => Create(new TimeSpan(start), new TimeSpan(end));
}