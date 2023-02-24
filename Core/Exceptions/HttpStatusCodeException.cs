using System;
using System.Net;

namespace Core.Exceptions {
    public struct ErrorMessage {
        public const string PermissionDenied = "Permission Denied."; // 403
        public const string DoesNotExist = "The ({0}) you specified does not exist."; // 404
        public const string DoesNotMatch = "The number of ({0}) does not match with the ({1})!"; // 400
        public const string NameDenied = "Username is not suitable."; // 400
        public const string MessageNotExist = "The message does not exist"; // 400
        public const string NotAllowed = "This method not allowed."; // 423
    }

    public class HttpStatusCodeException : Exception {
        public HttpStatusCode StatusCode { get; private set; }
        public HttpStatusCodeException(HttpStatusCode statusCode, string message, params object[] args) : base(string.Format(message, args)) {
            StatusCode = statusCode;
        }
    }
}
