namespace HiRezApi.Common
{
    using System;

    public sealed class DateTimeUtcTimeStampProvider : ITimeStampProvider
    {
        public DateTime ProvideTime()
        {
            return DateTime.UtcNow;
        }
    }
}