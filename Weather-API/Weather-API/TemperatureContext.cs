namespace Weather.API;

public class TemperatureContext
{
    public string? Sector { get; set; }
    public DateTime Time { get; set; }
    public double TemperatureC { get; set; }
    public double TemperatureF { get; set; }
}