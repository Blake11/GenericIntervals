using System.Numerics;
using GenericIntervals.Core;

namespace GenericIntervals.Numbers;

public static class NumberInterval
{
    public static NumberInterval<TUnit> Create<TUnit>(TUnit start, TUnit end) 
        where TUnit : INumber<TUnit> 
        => new(start, end);

    public static NumberInterval<TUnit> Empty<TUnit>()
        where TUnit : INumber<TUnit>
        => EmptyInterval<NumberInterval<TUnit>, TUnit>.Value;
}