namespace HiRezApi.Common
{
    internal class Constants
    {
        public const int SESSION_EXPIRATION_TIME_MINUTES = 15;

        public const string SESSION_APPROVED_RET_MSG = "Approved";

        public const string SESSION_EXCEPTION_DEVELOPER_ACCESS_RET_MSG = "Exception while validating developer access.Invalid signature.";

        public const string SESSION_REQUEST_LIMIT_REACHED_RET_MSG = "Daily request limit reached";

        public const string SESSION_INVALID_SESSION_ID_RET_MSG = "Invalid session id.";

        public const string SESSION_TIMESTAMP_INVALID_RET_MSG = "Error while comparing Server and Client timestamp";
    }
}