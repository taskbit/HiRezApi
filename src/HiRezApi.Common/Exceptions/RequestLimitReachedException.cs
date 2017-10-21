namespace HiRezApi.Common.Exceptions
{
    using System;

    public class RequestLimitReachedException : SessionException
    {
        public RequestLimitReachedException()
        {
        }

        public RequestLimitReachedException(string msg, Exception inner)
            : base(msg, inner)
        {
        }

        public RequestLimitReachedException(string msg)
            : base(msg)
        {
        }
    }
}