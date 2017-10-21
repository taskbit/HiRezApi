namespace HiRezApi.Common.Exceptions
{
    using System;
    using HiRezApi.Common.Models;

    public class HiRezApiException : Exception
    {
        public HiRezApiException()
        {
        }

        public HiRezApiException(string msg, Exception inner, ErrorModelException error)
            : base(msg, inner)
        {
            this.ErrorModel = error;
        }

        public HiRezApiException(string msg, Exception inner)
            : base(msg, inner)
        {
        }

        public HiRezApiException(string msg)
            : base(msg)
        {
        }

        public ErrorModelException ErrorModel { get; }
    }
}