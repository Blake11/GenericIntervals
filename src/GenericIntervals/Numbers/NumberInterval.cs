using System.Numerics;
using GenericIntervals.Core;

namespace GenericIntervals.Numbers;

/// <summary>
/// A Generic Number Interval using Generic Math (INumber&lt;TUnit&gt;)
/// </summary>
/// <param name="Start">The start of the interval</param>
/// <param name="End">The end of the interval</param>
public readonly record struct NumberInterval<TUnit>(
    TUnit Start,
    TUnit End
) : IInterval<TUnit> where TUnit : INumber<TUnit>
{
    public bool IsEmpty() => this is { Start: null, End: null } || Start == End;
}