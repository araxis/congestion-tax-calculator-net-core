using System;

namespace congestion.calculator;

public interface ITollFreeDateChecker
{
    bool IsTollFreeDate(DateTime date, CongestionTollConfigs configs);
}