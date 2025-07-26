namespace GenericIntervals.Core;

public static class EmptyInterval<TInterval, TUnit> where TInterval : IInterval<TUnit>?, new()
{
    public static readonly TInterval Value = new();
}