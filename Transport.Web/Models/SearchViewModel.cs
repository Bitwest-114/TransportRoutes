namespace Transport.Web.Models;

// Дані форми, результати пошуку і повідомлення про помилку.
public class SearchViewModel
{
    public string Departure { get; set; } = "";
    public string Destination { get; set; } = "";
    public List<TransportRoute> Routes { get; set; } = new List<TransportRoute>();
    public string? Error { get; set; }
}
