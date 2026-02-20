using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Net.Sockets;

namespace template_clean_arq_api.Presentation.Middleware
{
    internal static class StatusCode
    {
        internal static readonly Dictionary<Type, HttpStatusCode> ExceptionStatusCodeMap = new()
        {
            { typeof(SecurityTokenExpiredException), HttpStatusCode.Unauthorized },
            { typeof(SecurityTokenInvalidSignatureException), HttpStatusCode.Unauthorized },
            { typeof(SecurityTokenValidationException), HttpStatusCode.Forbidden },
            { typeof(UnauthorizedAccessException), HttpStatusCode.Unauthorized },
            { typeof(ArgumentException), HttpStatusCode.BadRequest },
            { typeof(ArgumentNullException), HttpStatusCode.BadRequest },
            { typeof(ArgumentOutOfRangeException), HttpStatusCode.BadRequest },
            { typeof(InvalidOperationException), HttpStatusCode.BadRequest },
            { typeof(FormatException), HttpStatusCode.BadRequest },
            { typeof(KeyNotFoundException), HttpStatusCode.NotFound },
            { typeof(FileNotFoundException), HttpStatusCode.NotFound },
            { typeof(DirectoryNotFoundException), HttpStatusCode.NotFound },
            { typeof(EndOfStreamException), HttpStatusCode.NotFound },
            { typeof(ObjectDisposedException), HttpStatusCode.Gone },
            { typeof(TimeoutException), HttpStatusCode.RequestTimeout },
            { typeof(TaskCanceledException), HttpStatusCode.RequestTimeout },
            { typeof(OperationCanceledException), HttpStatusCode.RequestTimeout },
            { typeof(NotSupportedException), HttpStatusCode.MethodNotAllowed },
            { typeof(NotImplementedException), HttpStatusCode.NotImplemented },
            { typeof(IOException), HttpStatusCode.InternalServerError },
            { typeof(OutOfMemoryException), HttpStatusCode.InsufficientStorage },
            { typeof(InsufficientMemoryException), HttpStatusCode.InsufficientStorage },
            { typeof(HttpRequestException), HttpStatusCode.BadGateway },
            { typeof(SocketException), HttpStatusCode.BadGateway },
            { typeof(WebException), HttpStatusCode.BadGateway }
        };
    }
}
