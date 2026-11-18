var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// маршрути
List<TransportRoute> routes = new List<TransportRoute>
{
    new TransportRoute("Львів — Київ", "Львів", "Київ", new List<string> { "Львів", "Рівне", "Житомир", "Київ" }, "08:15", 700),
    new TransportRoute("Львів — Івано-Франківськ", "Львів", "Івано-Франківськ", new List<string> { "Львів", "Стрий", "Калуш", "Івано-Франківськ" }, "09:30", 350),
    new TransportRoute("Івано-Франківськ — Київ", "Івано-Франківськ", "Київ", new List<string> { "Івано-Франківськ", "Львів", "Рівне", "Житомир", "Київ" }, "11:00", 900),
    new TransportRoute("Київ — Одеса", "Київ", "Одеса", new List<string> { "Київ", "Умань", "Одеса" }, "10:00", 550)
};

app.MapGet("/api/routes", (string departure, string destination) =>
{
    List<TransportRoute> foundRoutes = new List<TransportRoute>();

    foreach (TransportRoute route in routes)
    {
        if (route.Departure.Equals(departure, StringComparison.OrdinalIgnoreCase) &&
            route.Destination.Equals(destination, StringComparison.OrdinalIgnoreCase))
        {
            foundRoutes.Add(route);
        }
    }

    return Results.Ok(foundRoutes);
});

app.Run();

public class TransportRoute
{
    public string RouteName { get; set; }
    public string Departure { get; set; }
    public string Destination { get; set; }
    public List<string> Stops { get; set; }
    public string DepartureTime { get; set; }
    public decimal Price { get; set; }

    public TransportRoute(string routeName, string departure, string destination, List<string> stops, string departureTime, decimal price)
    {
        RouteName = routeName;
        Departure = departure;
        Destination = destination;
        Stops = stops;
        DepartureTime = departureTime;
        Price = price;
    }
}
