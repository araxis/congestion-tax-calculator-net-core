using congestion.calculator;
using Microsoft.EntityFrameworkCore;

namespace Congestion.Infrastructure;

public class CongestionTollConfigsRepository:ICongestionTaxConfigsRepository
{
    private readonly AppDbContext _appDbContext;

    public CongestionTollConfigsRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<CongestionTollConfigs> GetAsync(int cityId) => 
        await _appDbContext.
            CongestionTollConfigs.SingleAsync(c => c.City.Id == cityId);
}