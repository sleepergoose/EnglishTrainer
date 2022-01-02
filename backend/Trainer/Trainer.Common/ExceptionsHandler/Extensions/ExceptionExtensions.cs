using System;
using System.Net;

namespace Trainer.Common.ExceptionsHandler.Extensions
{
    public static class ExceptionExtensions
    {
        public static (HttpStatusCode, string message) ParseException(this Exception exception)
        {
            return exception switch
            {
                ArgumentNullException _ => (HttpStatusCode.BadRequest, exception.Message),
                ArgumentException _ => (HttpStatusCode.BadRequest, exception.Message),
                _ => (HttpStatusCode.InternalServerError, exception.Message)
            };
        }
    }
}
