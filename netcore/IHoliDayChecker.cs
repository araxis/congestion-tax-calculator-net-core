using System;

namespace congestion.calculator;

public interface IHolidayChecker
{
    bool IsHoliday(DateTime date);
    bool IsBeforeHoliday(DateTime date);
}