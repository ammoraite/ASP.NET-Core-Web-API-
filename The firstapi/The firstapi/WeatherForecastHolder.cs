using The_firstapi;

public class WeatherForecastHolder
{
    public List<WeatherForecast> _weathers=new List<WeatherForecast>();

    public void Add(WeatherForecast weatherForAdd)
    {
        WeatherForecast weathernow = new WeatherForecast();
        weathernow.Date = DateTime.Now;
        weathernow.TemperatureC = weatherForAdd.TemperatureC;
        weathernow.Summary = weatherForAdd.Summary;
        _weathers.Add(weathernow);
    }

    
    
    
}