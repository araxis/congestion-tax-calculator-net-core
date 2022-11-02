using congestion.calculator;
using Microsoft.AspNetCore.Mvc;

namespace Congestion.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TollFeeController : ControllerBase
    {

        private readonly ICongestionTollFeeCalculator _calculator;


        public TollFeeController(ICongestionTollFeeCalculator calculator)
        {
            _calculator = calculator;
        }

        [HttpPost]
        public async Task<int> Get(int cityId,VehicleType vehicleType, DateTime[] dates)
        {
            return await _calculator.GetTollFee(cityId, vehicleType, dates);
        }
    }
}