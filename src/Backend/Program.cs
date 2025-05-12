using Backend.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

string[] summaries = ["Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"];

app.MapGet("/", () => "Hello World!");

app.MapGet("/weather", async () => {
    // Simulate asynchronous loading to demonstrate streaming rendering
    await Task.Delay(500);

    var startDate = DateOnly.FromDateTime(DateTime.Now);
    var forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
    {
        Date = startDate.AddDays(index),
        TemperatureC = Random.Shared.Next(-20, 55),
        Summary = summaries[Random.Shared.Next(summaries.Length)]
    }).ToArray();

    return Results.Ok(forecasts);
});

app.Run();
