using congestion.calculator;
using Congestion.Infrastructure;

namespace Congestion.Api;

public static class Extensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>();
        services.AddScoped<ICongestionTaxConfigsRepository, CongestionTollConfigsRepository>();
        return services;
    }

    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddTransient<IHolidayChecker, HolidayChecker>();
        services.AddTransient<ITollFreeDateChecker, TollFreeDateChecker>();
        services.AddTransient<ITollFreeVehicleChecker, TollFreeVehicleChecker>();
        services.AddTransient<ICongestionTollFeeCalculator, CongestionTollFeeCalculator>();
        return services;
    }
}