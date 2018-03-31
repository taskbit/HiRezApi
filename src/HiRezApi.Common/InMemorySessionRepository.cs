namespace HiRezApi.Common
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class InMemorySessionRepository : ISessionRepository
    {
        private readonly Dictionary<Platform, HiRezApiSession> _sessions = new Dictionary<Platform, HiRezApiSession>();

        public Task<HiRezApiSession> GetAsync(Platform platform)
        {
            if (this._sessions.TryGetValue(platform, out HiRezApiSession session))
                return Task.FromResult(session);

            return Task.FromResult<HiRezApiSession>(null);
        }

        public Task RemoveAsync(Platform platform)
        {
            this._sessions[platform] = null;
            return Task.CompletedTask;
        }

        public Task SetAsync(HiRezApiSession session)
        {
            this._sessions[session.Platform] = session;
            return Task.CompletedTask;
        }
    }
}