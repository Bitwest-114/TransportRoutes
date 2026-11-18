namespace Transport.Web.Models;

// Ця модель має ті самі поля, що й відповідь API.
public class TransportRoute
{
    public string RouteName { get; set; } = "";
    public string Departure { get; set; } = "";
    public string Destination { get; set; } = "";
    public List<string> Stops { get; set; } = new List<string>();
    public string DepartureTime { get; set; } = "";
    public decimal Price { get; set; }
}
