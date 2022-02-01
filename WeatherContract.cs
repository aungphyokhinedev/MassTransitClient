namespace WeatherAPI;



public interface GetWeatherForecasts
{
}

public interface WeatherForecasts
{
    WeatherForecast[] Forecasts {  get; }
}

 public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
