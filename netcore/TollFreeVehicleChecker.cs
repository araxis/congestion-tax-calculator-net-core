using System;
using System.Linq;

namespace congestion.calculator;

public class TollFreeVehicleChecker : ITollFreeVehicleChecker
{

    public bool IsTollFreeVehicle(VehicleType vehicleType)
    {
        return vehicleType switch
        {
            VehicleType.Motorcycle => true,
            VehicleType.Tractor => false,
            VehicleType.Emergency => true,
            VehicleType.Diplomat => true,
            VehicleType.Foreign => true,
            VehicleType.Military => true,
            VehicleType.Truck => false,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}