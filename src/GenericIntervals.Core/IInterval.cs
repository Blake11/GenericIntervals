namespace GenericIntervals.Core;

/// <summary>
/// Represents a closed interval of type [Start, End] where Start and End are Typed
/// </summary>
/// <typeparam name="TUnit">The type of unit used for this interval</typeparam>
public interface IInterval<out TUnit>
{
    TUnit Start { get; }
    TUnit End { get; }

    bool IsEmpty();
}