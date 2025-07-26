namespace GenericIntervals.Core;

/// <summary>
/// Represents an operation from TInInterval&lt;TInUnit&gt; into multiple TOutInterval&lt;TOutUnit&gt;
/// </summary>
/// <typeparam name="TInInterval">The Type of input interval</typeparam>
/// <typeparam name="TInUnit">The Type of input interval unit</typeparam>
/// <typeparam name="TOutInterval">The Type of output interval</typeparam>
/// <typeparam name="TOutUnit">The Type of output interval unit</typeparam>
public interface IIntervalOperation<in TInInterval, TInUnit, out TOutInterval, TOutUnit>
    where TInInterval : IInterval<TInUnit>
    where TOutInterval : IInterval<TOutUnit>
{
    IEnumerable<TOutInterval> Apply(TInInterval interval);
}

/// <summary>
/// Represents the simplified operation for TInterval&lt;TUnit&gt; when TInUnit and TOutUnit Types are the same
/// </summary>
/// <typeparam name="TInterval">The Type of input interval</typeparam>
/// <typeparam name="TUnit">The Type of input interval unit</typeparam>
public interface IIntervalOperation<TInterval, TUnit>
    : IIntervalOperation<TInterval, TUnit, TInterval, TUnit>
    where TInterval : IInterval<TUnit>;