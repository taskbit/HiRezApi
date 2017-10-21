namespace HiRezApi.Common.Exceptions
{
    using System;

    public class SessionException : HiRezApiException
    {
        public SessionException()
        {
        }

        public SessionException(string msg, Exception inner)
            : base(msg, inner)
        {
        }

        public SessionException(string msg)
            : base(msg)
        {
        }
    }
}