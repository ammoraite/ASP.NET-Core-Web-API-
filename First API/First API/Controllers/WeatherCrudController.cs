using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace First_API.Controllers
{
    [Route("api/weathercrud")]
    [ApiController]
    public class WeatherCrudController : ControllerBase
    {

        private readonly WetherForCastHolder _holder=new WetherForCastHolder();
            
        public WeatherCrudController(WetherForCastHolder holder)        
        {
            _holder = holder;
        }

        [HttpPost("weathercreate")]
        public IActionResult Create([FromQuery] string input)
        {
            _holder.Add(new WeatherForecast(input));
            return Ok();
        }

        [HttpGet("weatherread")]
        public IActionResult Read()
        {
            return Ok(_holder.Get());
        }

        [HttpPut("weatherupdate")]
        public IActionResult Update(
            [FromQuery] string weatherSummaryToUpdate,
            [FromQuery] string newWeatherSummaryValue)
        {
            for (int i = 0; i < _holder.Values.Count; i++)
            {
                if (weatherSummaryToUpdate != null && _holder.Values[i].Summary == weatherSummaryToUpdate)
                {
                    _holder.Values[i].Summary = newWeatherSummaryValue;
                }
            }
            return Ok();
        }

        [HttpDelete("weatherdelete")]
        public IActionResult Delete([FromQuery] string weatherSummaryToDelete)
        {
            _holder.Values = _holder.Values.Where(w => w.Summary !=
            weatherSummaryToDelete).ToList();
            return Ok();
        }
    }
}