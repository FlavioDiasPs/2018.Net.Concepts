
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CreatingMiddleware
{
    public class MyFileLoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly MyFileLoggerOptions _options;

        public MyFileLoggerMiddleware(RequestDelegate next, IOptions<MyFileLoggerOptions> options)
        {
            _next = next;
            _options = options.Value;
        }

        public async Task Invoke(HttpContext context)
        {
            var request = context.Request;
            var requestLogMessage = $"REQUEST:\n{request.Method} - {request.Path.Value}{request.QueryString}";
            requestLogMessage += $"\nContentType: {request.ContentType ?? "Not specified"}";
            requestLogMessage += $"\nHost: {request.Host}";
            File.AppendAllText(_options.fileUrl , $"{DateTime.Now.ToString("s")}\n{requestLogMessage}");

            await _next(context);

            var response = context.Response;
            var responseLogMessage = $"\nRESPONSE:\nStatus Code: {response.StatusCode}";
            File.AppendAllText(_options.fileUrl, $"{responseLogMessage}\n\n");
        }
    }
}
