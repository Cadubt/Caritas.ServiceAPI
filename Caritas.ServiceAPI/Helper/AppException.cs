using System;

namespace Caritas.ServiceAPI.Helper
{
    public class AppException : Exception
    {
        public override string Message { get; }
        public int Code { get; }

        public AppException(string message, int code = 500)
        {
            this.Code = code;
            this.Message = message;
        }
        public AppException(AppException ex)
        {
            this.Code = ex.Code;
            this.Message = ex.Message;
        }
    }
}
