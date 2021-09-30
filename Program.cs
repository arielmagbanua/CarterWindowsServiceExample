using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace AmazingService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .UseWindowsService()
                .ConfigureWebHostDefaults(webBuilder => {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseUrls("http://*:8823");
                })
                .Build();

            host.Run();
        }
    }
}
