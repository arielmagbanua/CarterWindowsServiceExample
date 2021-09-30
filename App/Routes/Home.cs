using Carter;
using AmazingService.Extensions.Response;
using Microsoft.Extensions.Logging;

namespace AmazingService
{
    public class Home : CarterModule
    {
        private readonly ILogger<Home> _logger;

        public Home(ILogger<Home> logger)
        {
            _logger = logger;

            _logger.LogInformation("Something!!!");

            // Get("/", async(req, res) => await res.WriteAsync("Hello from Carter!"));
            Get("/", async (req, res) => await res.SendFileResponse("/Views/index.html", "text/html"));
        }
    }
}
