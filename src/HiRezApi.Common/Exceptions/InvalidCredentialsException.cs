namespace HiRezApi.Common.Exceptions
{
    using System;

    public class InvalidCredentialsException : SessionException
    {
        public InvalidCredentialsException()
        {
        }

        public InvalidCredentialsException(string msg, Exception inner)
            : base(msg, inner)
        {
        }

        public InvalidCredentialsException(string msg)
            : base(msg)
        {
        }
    }
}