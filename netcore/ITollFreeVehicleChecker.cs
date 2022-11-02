using System.Threading.Tasks;

namespace congestion.calculator;

public interface ITollFreeVehicleChecker
{
    bool IsTollFreeVehicle(VehicleType vehicleType);
}