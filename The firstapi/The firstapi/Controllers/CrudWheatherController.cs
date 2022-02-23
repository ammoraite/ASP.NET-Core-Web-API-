using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace The_firstapi.Controllers
{
    [Route("CrudWheather")]
    [ApiController]
    public class CrudWheatherController : ControllerBase
    {
        private readonly WeatherForecastHolder _holder;
        private readonly WeatherForecastController _weather;
       
        public CrudWheatherController(WeatherForecastHolder holder)
        {
            _holder = holder;
        }
        private readonly ILogger<CrudWheatherController> _logger;

        [HttpPost("CrudWheather/SaveTemp")]
        /// <summary>Возможность сохранить температуру в указанное время</summary>
        public IActionResult SaveTemp()
        { 
            foreach (var item in _weather.Get())
            {
                _holder.Add(item);
            } 
            return Ok();
        }
        
        [HttpGet("CrudWheather/read")]
        /// <summary>Возможность прочитать список показателей температуры за указанный промежуток времени</summary>
        public IActionResult Read([FromQuery] int days)
        {
            return Ok(Enumerable.Range(1, days).Select(index => _holder._weathers)
             .ToArray());
        }

        [HttpPut("CrudWheather/update")]
        /// <summary>Возможность отредактировать показатель температуры в указанное время</summary>
        public IActionResult Update([FromQuery] DateTime dateTime, [FromQuery] int temp)
        {
            foreach (var item in _holder._weathers)
            {
                if (dateTime== item.Date)
                {
                    item.TemperatureC=temp;
                }
            }
            return Ok();
        }

        public WeatherForecastHolder Get_holder()
        {
            return _holder;
        }

        [HttpDelete("CrudWheather/delete")]
        /// <summary>Возможность удалить показатель температуры в указанный промежуток времени.</summary>
        public IActionResult Delete([FromQuery] int days)
        {
            for (int i = 0; i < days; i++)
            {
                _holder._weathers.Remove(_holder._weathers[i]);
            }
            return Ok();
        }
    }
}


