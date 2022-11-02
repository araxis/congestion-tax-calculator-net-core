using System.Threading.Tasks;

namespace congestion.calculator;

public interface ICongestionTaxConfigsRepository
{
    Task<CongestionTollConfigs> GetAsync(int cityId);
}