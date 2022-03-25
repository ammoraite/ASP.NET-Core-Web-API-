using System;

namespace First_API.Controllers
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }

        public WeatherForecast(string sammary)
        {
            Random random = new Random();
            TemperatureC = random.Next(1, 30);
            Summary = sammary;
        }
        public WeatherForecast()
        { }
    }
}