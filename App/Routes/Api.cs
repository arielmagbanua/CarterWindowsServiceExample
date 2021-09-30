using Carter;
using AmazingService.Extensions.Response;
using System.Collections.Generic;
using Carter.Response;

namespace AmazingService.App.Routes
{
    public class Api : CarterModule
    {
        public Api() : base("api")
        {
            this.RequiresAuthorization();

            // Get("/", async (req, res) => await res.WriteAsync("Amazing Carter!"));
            Get("/", async (req, res) => await res.SendFileResponse("/Views/api.html", "text/html"));

            var data = new Dictionary<string, string>();
            data.Add("title", "Foo Title");
            data.Add("message", "The quick brown fox!");

            Get("/json", async (req, res) => await res.AsJson(data));
        }
    }
}
