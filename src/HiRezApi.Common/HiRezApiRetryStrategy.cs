namespace HiRezApi.Common
{
    using System;
    using System.Net;
    using HiRezApi.Common.Exceptions;
    using HiRezApi.Common.Models;
    using Microsoft.Rest.TransientFaultHandling;

    public class HiRezApiRetryStrategy : ITransientErrorDetectionStrategy
    {
        public virtual bool IsTransient(Exception ex)
        {
            // Retry request on a session exception, except if the request limit was reached or the credentials are wrong
            if (ex is SessionException)
            {
                if (ex is InvalidCredentialsException)
                    return false;

                if (ex is RequestLimitReachedException)
                    return false;

                if (ex is InvalidSessionException)
                    return false;

                return true;
            }

            if (ex is ApiUnavailableException)
                return true;

            if (ex is ErrorModelException errorException)
                if (errorException.Response != null && MayRetry(errorException.Response.StatusCode))
                    return true;

            if (ex is HttpRequestWithStatusException withStatusException)
                if (MayRetry(withStatusException.StatusCode))
                    return true;

            if (ex is HiRezApiException hiRezApiException)
                if (hiRezApiException.ErrorModel?.Response != null && MayRetry(hiRezApiException.ErrorModel.Response.StatusCode))
                    return true;

            return false;
        }

        private static bool MayRetry(HttpStatusCode statusCode)
        {
            return statusCode == HttpStatusCode.RequestTimeout || statusCode >= HttpStatusCode.InternalServerError
                   && statusCode != HttpStatusCode.NotImplemented && statusCode != HttpStatusCode.HttpVersionNotSupported;
        }
    }
}