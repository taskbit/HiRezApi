namespace HiRezApi.Common
{
    using System;

    public sealed class HiRezApiSession : IEquatable<HiRezApiSession>
    {
        private readonly ITimeStampProvider _timeStampProvider;

        internal HiRezApiSession(DateTime createdAt, string sessionId, ITimeStampProvider timeStampProvider)
        {
            this.CreatedAt = createdAt;
            this.SessionId = sessionId;
            this._timeStampProvider = timeStampProvider;
        }

        public DateTime CreatedAt { get; }

        public bool IsValid => !string.IsNullOrEmpty(this.SessionId)
                               && this.CreatedAt.AddMinutes(Constants.SESSION_EXPIRATION_TIME_MINUTES) > this._timeStampProvider.ProvideTime();

        public string SessionId { get; }

        public bool Equals(HiRezApiSession other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(this.SessionId, other.SessionId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return this.Equals((HiRezApiSession) obj);
        }

        public override int GetHashCode()
        {
            return this.SessionId != null ? this.SessionId.GetHashCode() : 0;
        }

        public static bool operator ==(HiRezApiSession left, HiRezApiSession right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(HiRezApiSession left, HiRezApiSession right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return $"{nameof(this.CreatedAt)}: {this.CreatedAt}, {nameof(this.IsValid)}: {this.IsValid}, {nameof(this.SessionId)}: {this.SessionId}";
        }
    }
}