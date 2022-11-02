using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace congestion.calculator;

public class CongestionTollFeeCalculator : ICongestionTollFeeCalculator
{

   

    private readonly ITollFreeDateChecker _freeDateChecker;
    private readonly ITollFreeVehicleChecker _freeVehicleChecker;
    private readonly ICongestionTaxConfigsRepository _configsRepository;
    public CongestionTollFeeCalculator(ICongestionTaxConfigsRepository configsRepository, ITollFreeDateChecker freeDateChecker, ITollFreeVehicleChecker freeVehicleChecker)
    {
        _configsRepository = configsRepository;
        _freeDateChecker = freeDateChecker;
        _freeVehicleChecker = freeVehicleChecker;
    }

    /**
         * Calculate the total toll fee for one day
         *
         * @param vehicle - the vehicle
         * @param dates   - date and time of all passes on one day
         * @return - the total congestion tax for that day
         */

    public async Task<int> GetTollFee(int cityId,VehicleType vehicleType, DateTime[] dates)
    {
        if (_freeVehicleChecker.IsTollFreeVehicle(vehicleType)) return 0;
        var configs = await _configsRepository.GetAsync(cityId);
        var dayGroups = dates.OrderBy(d=>d).GroupBy(DateOnly.FromDateTime);

        return dayGroups.Sum(group => TotalFeePerDay( group.ToList(), configs));
    }

    private int TotalFeePerDay(IReadOnlyList<DateTime> dates, CongestionTollConfigs configs)
    {
        var intervalStart = dates[0];
        if (_freeDateChecker.IsTollFreeDate(intervalStart, configs)) return 0;
        var totalFee = 0;
      
        foreach (var date in dates.ToList())
        {
            var nextFee = configs.GetToolFee(date);
            var tempFee = configs.GetToolFee(date);
            var minutes = (date - intervalStart).TotalMinutes;

            if (minutes <= 60)
            {
                if (totalFee > 0) totalFee -= tempFee;
                if (nextFee >= tempFee) tempFee = nextFee;
                totalFee += tempFee;
            }
            else
            {
                intervalStart = date;
                totalFee += nextFee;
            }

            if (totalFee >= configs.MaxFeePerDay) return configs.MaxFeePerDay;
        }

        return totalFee;
    }
}