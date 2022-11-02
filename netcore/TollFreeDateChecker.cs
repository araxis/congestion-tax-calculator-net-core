using System;

namespace congestion.calculator;

public class TollFreeDateChecker : ITollFreeDateChecker
{
    private readonly IHolidayChecker _holidayChecker;
    public TollFreeDateChecker(IHolidayChecker holidayChecker)
    {
        _holidayChecker = holidayChecker;
    }

    public  bool IsTollFreeDate(DateTime date, CongestionTollConfigs configs)
    {
        if (date.Month == configs.FreeMonth) return true;
        if (configs.FreeOnWeekend && date.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday) return true;

        if (configs.FreeOnPublicHolidays &&  _holidayChecker.IsHoliday(date)) return true;

        return configs.FreeOnDayBeforeHoliday && _holidayChecker.IsBeforeHoliday(date);
    }
}