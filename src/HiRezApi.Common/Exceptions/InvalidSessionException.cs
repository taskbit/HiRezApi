namespace HiRezApi.Common.Exceptions
{
    using System;

    public class InvalidSessionException : SessionException
    {
        public InvalidSessionException()
        {
        }

        public InvalidSessionException(string msg, Exception inner)
            : base(msg, inner)
        {
        }

        public InvalidSessionException(string msg)
            : base(msg)
        {
        }
    }
}