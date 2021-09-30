using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace AmazingService.App.Auth
{
    /// <summary>
    /// The custom authorization handler for any incoming request to protected route modules.
    /// </summary>
    public class InfusionAuthHandler : AuthenticationHandler<InfusionAuthOptions>
    {
        public InfusionAuthHandler(IOptionsMonitor<InfusionAuthOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
        }

        /// <summary>
        /// Authenticate request
        /// </summary>
        /// <returns>Returns an asynchronous task instance.</returns>
        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            // Get Authorization header value
            if (!Request.Headers.TryGetValue(HeaderNames.Authorization, out var authorization))
            {
                return Task.FromResult(AuthenticateResult.Fail("Cannot read authorization header."));
            }

            // The auth key from Authorization header check against the configured ones
            if (authorization.Any(key => Options.AuthKey.All(ak => ak != key)))
            {
                return Task.FromResult(AuthenticateResult.Fail("Invalid auth key."));
            }

            // get the client id from auth header value
            var clientId = authorization.ToString().Split("_")[0];

            // Create authenticated user
            var identities = new List<ClaimsIdentity> { new ClaimsIdentity(new[] { new Claim("adapter_auth_claim", clientId) }, "adapter_auth") };
            var ticket = new AuthenticationTicket(new ClaimsPrincipal(identities), Options.Scheme);

            return Task.FromResult(AuthenticateResult.Success(ticket));
        }
    }
}
