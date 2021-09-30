using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Primitives;

namespace AmazingService.App.Auth
{
    /// <summary>
    /// Custom authentication scheme option class for Infusion.
    /// </summary>
    public class AuthOptions : AuthenticationSchemeOptions
    {
        public const string DefaultScheme = "Infusion Adapter";

        public string Scheme => DefaultScheme;

        public StringValues AuthKey { get; set; }
    }
}
