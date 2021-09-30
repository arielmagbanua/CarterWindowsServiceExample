using Carter;
using AmazingService.Extensions.Response;
using Microsoft.Extensions.Logging;

namespace AmazingService
{
    public class HomeModule : CarterModule
    {
        private readonly ILogger<HomeModule> _logger;

        public HomeModule(ILogger<HomeModule> logger)
        {
            _logger = logger;

            _logger.LogInformation("Something!!!");

            // Get("/", async(req, res) => await res.WriteAsync("Hello from Carter!"));
            Get("/", async (req, res) => await res.SendFileResponse("/Views/index.html", "text/html"));
        }
    }
}
