namespace GenericIntervals.DateTimeIntervals;

public partial record struct DateTimeInterval
{
    
    /// <summary>
    /// Create a new instance of DateTimeInterval
    /// </summary>
    /// <param name="start">Starting Date</param>
    /// <param name="end">Ending Date</param>
    /// <returns>Returns a new instance of DateTimeInterval</returns>
    public static DateTimeInterval Create(DateTime start, DateTime end)
        => new(start, end);

    /// <summary>
    /// Create the interval from ticks
    /// </summary>
    /// <param name="start">Starting tick</param>
    /// <param name="end">Ending Tick</param>
    /// <returns>Returns a new instance of DateTimeInterval using ticks as the constructor for DateTime</returns>
    public static DateTimeInterval FromTicks(long start, long end)
        => Create(new DateTime(start), new DateTime(end));
}