using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PortfolioWebsite.Models;
using PortfolioWebsite.Services;

namespace PortfolioWebsite.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly VisitorLogService _visitorLogService;

    public HomeController(ILogger<HomeController> logger, VisitorLogService visitorLogService)
    {
        _logger = logger;
        _visitorLogService = visitorLogService;
    }

    public async Task<IActionResult> Index()
    {
        var ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
        var userAgent = Request.Headers["User-Agent"].ToString();
        var referrer = Request.Headers["Referer"].ToString();
        var sessionId = HttpContext.Session.Id;

        var visitorLog = new VisitorLog
        {
            IPAddress = ipAddress ?? "Unknown",
            UserAgent = userAgent,
            Referrer = referrer ?? "Direct Access",
            SessionId = sessionId,
            VisitTime = DateTime.UtcNow
        };

        await _visitorLogService.LogVisitorAsync(visitorLog);

        return View();
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
