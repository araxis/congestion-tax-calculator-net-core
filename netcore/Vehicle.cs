namespace congestion.calculator;

public record Vehicle(VehicleType Type);
    

public enum VehicleType
{
    Motorcycle = 0,
    Tractor = 1,
    Emergency = 2,
    Diplomat = 3,
    Foreign = 4,
    Military = 5,
    Truck=6
}