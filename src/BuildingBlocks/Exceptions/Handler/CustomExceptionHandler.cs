using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BuildingBlocks.Exceptions.Handler
{
    internal class CustomExceptionHandler (ILogger<CustomExceptionHandler> logger): IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext context, Exception exception, CancellationToken cancellationToken)
        {
            logger.LogError(
                $"Error Message: {exception.Message} ,Time of occurence {DateTime.UtcNow}"
                );



        }
    }
}
