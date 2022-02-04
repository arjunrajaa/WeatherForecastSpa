using System.Collections.Generic;
using WeatherForecast.Common;

public class City
{
    public int id { get; set; }
    public string name { get; set; }
    public Coord coord { get; set; }
    public string country { get; set; }
    public int Sunrise { get; set; }
    public int Sunset { get; set; }
}
public class RootWeather
{
    public string cod { get; set; }
    public double message { get; set; }
    public int cnt { get; set; }
    public List<List> list { get; set; }
    public City city { get; set; }
}