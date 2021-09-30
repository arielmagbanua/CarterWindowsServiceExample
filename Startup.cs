using AmazingService.App.Auth;
using Carter;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AmazingService
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // carter and routing services
            services.AddCarter();
            services.AddRouting();
            services.AddHostedService<Worker>();

            services.AddLogging(loggingBuilder => loggingBuilder.AddFile("app.log", append: true));

            services.AddAuthentication((options) =>
            {
                options.DefaultAuthenticateScheme = AuthOptions.DefaultScheme;
                options.DefaultChallengeScheme = AuthOptions.DefaultScheme;
            })
                .AddCustomAuth((options) =>
                {
                    options.AuthKey = "foo_key";
                });

            services.AddAuthorization();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(builder => builder.MapCarter());
        }
    }
}
