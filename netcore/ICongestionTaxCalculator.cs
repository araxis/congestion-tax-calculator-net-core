using System;
using System.Threading.Tasks;

namespace congestion.calculator;

public interface ICongestionTollFeeCalculator
{
 
    Task<int> GetTollFee(int cityId,VehicleType vehicleType, DateTime[] dates);
}