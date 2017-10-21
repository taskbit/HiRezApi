namespace HiRezApi.Common
{
    using System;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;
    using HiRezApi.Common.Exceptions;
    using HiRezApi.Common.Models;
    using Microsoft.Rest;

    public class DefaultSessionProvider : ISessionProvider
    {
        // Ensure that the request to create a session is thread-safe
        // If a session expires this will prevent multiple parallel requests to createsession
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1);

        private readonly ITimeStampProvider _timeStampProvider;
        private IHiRezApiClient _apiClient;
        private HiRezApiSession _currentSession;

        public DefaultSessionProvider(ITimeStampProvider timeStampProvider)
        {
            this._timeStampProvider = timeStampProvider;
        }

        public virtual async Task<HiRezApiSession> AcquireAsync()
        {
            await this._semaphore.WaitAsync();
            try
            {
                if (this._currentSession?.IsValid == true) return this._currentSession;
                return this._currentSession = await this.TryFetchNewSessionAsync();
            }
            finally
            {
                this._semaphore.Release();
            }
        }

        public virtual async Task ClearAsync()
        {
            await this._semaphore.WaitAsync();
            try
            {
                this._currentSession = null;
            }
            finally
            {
                this._semaphore.Release();
            }
        }

        public void ProvideClient(IHiRezApiClient client)
        {
            // Automatically called by ServiceClientCredentials.InitializeServiceClient() 
            this._apiClient = client ?? throw new ArgumentNullException(nameof(client));
        }

        private async Task<HiRezApiSession> TryFetchNewSessionAsync()
        {
            try
            {
                var sessionResponse = await this._apiClient.CreateSessionWithHttpMessagesAsync();

                if (sessionResponse.Body.RetMsg != Constants.SESSION_APPROVED_RET_MSG)
                {
                    var exMsg = $"Session was not approved: {sessionResponse.Body.RetMsg}";

                    switch (sessionResponse.Body.RetMsg)
                    {
                        case Constants.SESSION_REQUEST_LIMIT_REACHED_RET_MSG:
                            throw new RequestLimitReachedException(exMsg);
                        case Constants.SESSION_EXCEPTION_DEVELOPER_ACCESS_RET_MSG:
                            throw new InvalidCredentialsException(exMsg);
                        case Constants.SESSION_TIMESTAMP_INVALID_RET_MSG:
                            throw new InvalidSessionException(exMsg);
                        case Constants.SESSION_INVALID_SESSION_ID_RET_MSG:
                            throw new InvalidSessionException(exMsg);
                    }

                    throw new SessionException(exMsg);
                }

                if (string.IsNullOrEmpty(sessionResponse.Body.SessionId))
                    throw new SessionException("Session is missing from response.");

                if (!sessionResponse.Body.Timestamp.TryParseApiDate(out var sessionTimeStamp))
                    throw new SessionException("Could not validate timestamp.");

                // If a request reaches the API when the session expired we'll get an error
                // to prevent "most" of these issues we'll expire the session on the client a little bit earlier
                sessionTimeStamp = sessionTimeStamp.AddSeconds(-5);

                return new HiRezApiSession(sessionTimeStamp, sessionResponse.Body.SessionId, this._timeStampProvider);
            }
            catch (Exception ex) when (ex is ErrorModelException || ex is HttpOperationException)
            {
                var response = (ex as ErrorModelException)?.Response ?? (ex as HttpOperationException)?.Response;

                // Observings indicate that a 404 response can occur when the API is "down" (probably due to deployment errors)
                if (response?.StatusCode == HttpStatusCode.NotFound)
                    throw new ApiUnavailableException("API is not available.", ex);

                throw new SessionException("Failure creating a session.", ex);
            }
        }
    }
}