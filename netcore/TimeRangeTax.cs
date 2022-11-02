using System;

namespace congestion.calculator;

public class TimeRangeFee
{
    public TimeRangeFee(TimeOnly start, TimeOnly end, int amount)
    {
        Start = start;
        End = end;
        Amount = amount;
    }

    public TimeOnly End { get; }

    public TimeOnly Start { get; }

    public int Amount { get; }
}