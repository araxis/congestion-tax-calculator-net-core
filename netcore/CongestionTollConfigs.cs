using System;
using System.Collections.Generic;
using System.Linq;

namespace congestion.calculator;

public class CongestionTollConfigs
{

    public int Id { get;private set; }

    public City City { get; set; }
    public int MaxFeePerDay { get; set; }
    public IEnumerable<TimeRangeFee> TollFees { get; set; }

    public bool FreeOnWeekend { get; set; }
    public bool FreeOnPublicHolidays { get; set; }
    public bool FreeOnDayBeforeHoliday { get; set; }
    public int FreeMonth { get; set; }

    public int GetToolFee(DateTime date)
    {
        var time = TimeOnly.FromDateTime(date);
        var rangeTax = TollFees.OrderBy(c => c.Start).FirstOrDefault(c => time.IsBetween(c.Start, c.End));
        return rangeTax?.Amount ?? 0;
    }
  
}