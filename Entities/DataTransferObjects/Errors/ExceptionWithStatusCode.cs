using System;
using System.Net;

namespace Entities.DataTransferObjects.Errors
{
    public class ExceptionWithStatusCode: Exception
    {
        public HttpStatusCode StatusCode { get; }

        public ExceptionWithStatusCode(HttpStatusCode statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}