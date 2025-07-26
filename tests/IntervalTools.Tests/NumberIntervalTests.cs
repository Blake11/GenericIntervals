using GenericIntervals.DateTimeIntervals;
using GenericIntervals.Numbers;
using GenericIntervals.TimeSpanIntervals;
using Xunit;
using Xunit.Abstractions;

namespace TimeInterval.Tests;

public class TimeIntervalTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public TimeIntervalTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Test_Numbers()
    {
        var interval = NumberInterval.Create(0, 10);
        var divider = NumberIntervalDivider.Create<int, int>(2);
        var intervals = divider.Apply(interval);

        foreach (var timeInterval in intervals)
        {
            _testOutputHelper.WriteLine(timeInterval.ToString());
        }
    }

    [Fact]
    public void Test_DateTime()
    {
        var interval = DateTimeInterval.FromTicks(0, 100);
        var divider = new DateTimeTimespanIntervalDivider(TimeSpan.FromTicks(10));
        var intervals = divider.Apply(interval);

        foreach (var timeInterval in intervals)
        {
            _testOutputHelper.WriteLine(timeInterval.ToString());
        }
    }

    [Fact]
    public void Test_TimeSpan()
    {
        var interval = TimeSpanInterval.FromTicks(0, 100);
        var divider = new TimespanIntervalDivider(TimeSpan.FromTicks(10));
        var intervals = divider.Apply(interval);

        foreach (var timeInterval in intervals)
        {
            _testOutputHelper.WriteLine(timeInterval.ToString());
        }
    }
}