using Carter;
using AmazingService.Extensions.Response;

namespace AmazingService.App.Routes
{
    public class Api : CarterModule
    {
        public Api() : base("api")
        {
            this.RequiresAuthorization();

            // Get("/", async (req, res) => await res.WriteAsync("Amazing Carter!"));
            Get("/", async (req, res) => await res.SendFileResponse("/Views/api.html", "text/html"));
        }
    }
}
