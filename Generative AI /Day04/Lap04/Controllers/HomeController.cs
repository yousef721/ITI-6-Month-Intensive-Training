using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using Lap04.Models;
using System.Text.Json;
using Lap04.ViewModel;

namespace Lap04.Controllers;

public class HomeController : Controller
{
    private readonly IConfiguration _config;
    public HomeController(IConfiguration config)
    {
        _config = config;
    }
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult AiChat()
    {
        return View(new ChatViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> AiChat(string question)
    {
        HttpClient client = new();

        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _config["APIKey"]);

        var body = new
        {
            model = _config["ModelName"],
            messages = new[] {
                new { role = "user", content = question }
            }
        };

        var response = await client.PostAsJsonAsync(_config["EndPoint"], body);

        var result = await response.Content.ReadAsStringAsync();

        var doc = JsonDocument.Parse(result);

        var answer = doc.RootElement.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString();

        var model = new ChatViewModel
        {
            Question = question,
            Answer = answer
        };

        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
