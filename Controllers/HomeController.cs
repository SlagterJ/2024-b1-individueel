using System.Diagnostics;
using _2024_b1_individueel.Models;
using Microsoft.AspNetCore.Mvc;

namespace _2024_b1_individueel.Controllers;

public class HomeController(ILogger<HomeController> logger) : Controller
{
    public IActionResult Index() => View();

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() =>
        View(
            new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }
        );
}
