using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using Transport.Web.Models;

namespace Transport.Web.Controllers;

public class RoutesController : Controller
{
    private static readonly HttpClient Api = new HttpClient();

    public IActionResult Index()
    {
        return View(new SearchViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> Search(SearchViewModel model)
    {
        if (string.IsNullOrWhiteSpace(model.Departure) ||
            string.IsNullOrWhiteSpace(model.Destination))
        {
            model.Error = "Введіть обидва міста.";
            return View("Index", model);
        }

        try
        {
            string url = "http://localhost:5101/api/routes?departure="
                + Uri.EscapeDataString(model.Departure)
                + "&destination=" + Uri.EscapeDataString(model.Destination);

            model.Routes = await Api.GetFromJsonAsync<List<TransportRoute>>(url)
                ?? new List<TransportRoute>();

            if (model.Routes.Count == 0)
            {
                model.Error = "Маршрут не знайдено.";
            }
        }
        catch (HttpRequestException)
        {
            model.Error = "Сервіс маршрутів не запущено.";
        }

        return View("Index", model);
    }
}
