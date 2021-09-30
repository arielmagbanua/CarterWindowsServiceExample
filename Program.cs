using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace AmazingService
{
    public class Program
    {
        public Program()
        {
            // sets the directory of this service to the publish directory
            System.IO.Directory.SetCurrentDirectory(System.AppDomain.CurrentDomain.BaseDirectory);
        }

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
