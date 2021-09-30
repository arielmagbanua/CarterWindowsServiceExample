using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AmazingService.Extensions.Response
{
    /// <summary>
    /// Collection of HttpResponse extension for responding using static files.
    /// ASP .NET Core extensions resembles to PHP traits or Dart mixins.
    /// </summary>
    public static class FileResponse
    {
        /// <summary>
        /// Sending file response.
        /// 
        /// <example>
        /// <code>
        ///     return await res.SendFileResponse("/Views/index.html", "text/html")
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="res">Auto injected instance that is using this extension.</param>
        /// <param name="filePath">The path of file relative to the root of the project.</param>
        /// <param name="contentType">The content type of the response.</param>
        /// <returns>Returns the asynchronous task if sending the file as a response.</returns>
        public static Task SendFileResponse(this HttpResponse res, String filePath, String contentType = "text/plain")
        {
            // set the content type
            res.ContentType = contentType;

            // base path of the application
            var baseBath = Environment.CurrentDirectory;
            
            // var awts = Directory.GetParent(Environment.CurrentDirectory).FullName;
            // var baseBath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent;

            return res.SendFileAsync(baseBath + filePath);
        }
    }
}
