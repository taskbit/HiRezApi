namespace HiRezApi.Common.Exceptions
{
    using System;

    public class ApiUnavailableException : HiRezApiException
    {
        public ApiUnavailableException()
        {
        }

        public ApiUnavailableException(string msg, Exception inner)
            : base(msg, inner)
        {
        }

        public ApiUnavailableException(string msg)
            : base(msg)
        {
        }
    }
}