using Microsoft.AspNetCore.Authentication;
using System;

namespace AmazingService.App.Auth
{
    public static class AuthenticationBuilderExtensions
    {
        // Custom authentication extension method
        public static AuthenticationBuilder AddCustomAuth(this AuthenticationBuilder builder, Action<InfusionAuthOptions> configureOptions)
        {
            // Add custom authentication scheme with custom options and custom handler
            return builder.AddScheme<InfusionAuthOptions, InfusionAuthHandler>(InfusionAuthOptions.DefaultScheme, configureOptions);
        }
    }
}
