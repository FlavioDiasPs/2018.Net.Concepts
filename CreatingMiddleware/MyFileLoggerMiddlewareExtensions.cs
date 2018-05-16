using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreatingMiddleware
{
    public static class MyFileLoggerMiddlewareExtensions
    {
        public static IApplicationBuilder UseMyFileLogger(this IApplicationBuilder app, MyFileLoggerOptions options)
        {
            return app.UseMiddleware<MyFileLoggerMiddleware>(Options.Create(options));
        }
    }
}
