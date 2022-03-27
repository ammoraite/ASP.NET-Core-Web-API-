using System;

namespace First_API
{
    public class WeatherForecast
    {
        public WeatherForecast(string input)
        {
            Input = input;
        }
        public WeatherForecast(){}

        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
        public string Input { get; }
    }
}
