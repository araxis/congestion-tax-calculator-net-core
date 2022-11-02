using System;
using Nager.Date;

namespace congestion.calculator;

public class HolidayChecker:IHolidayChecker
{
    public bool IsHoliday(DateTime date)
    {
        return DateSystem.IsPublicHoliday(date, CountryCode.SE);
    }

    public bool IsBeforeHoliday(DateTime date)
    {
        return DateSystem.IsPublicHoliday(date.AddDays(1), CountryCode.SE);
    }
}