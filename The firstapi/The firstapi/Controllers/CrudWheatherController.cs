using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace The_firstapi.Controllers
{
    [ApiController]
    [Route("CrudWheather")]
    public class CrudWheatherController : ControllerBase
    {
        private readonly WeatherForecastHolder _holder=new WeatherForecastHolder();
        private readonly WeatherForecastController _weather=new WeatherForecastController();
        private readonly ILogger<CrudWheatherController> _logger;
        public CrudWheatherController(ILogger<CrudWheatherController> logger)
        {
            _logger = logger;
        }
        

        [HttpPost,Route("SaveTemp")]
        public IActionResult SaveTemp()
        { 
            foreach (var item in _weather.Get())
            {
                _holder.Add(item);
            } 
            return Ok();
        }
        
        [HttpGet,Route("read")]
        public IActionResult Read([FromQuery] int days)
        {
            return Ok(Enumerable.Range(1, days).Select(index => _holder._weathers).ToArray());
        }

        [HttpPut,Route("update")]
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

        [HttpDelete,Route("delete")]
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


