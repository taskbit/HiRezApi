namespace HiRezApi.Common
{
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    // This repository is not thread-safe on it's own
    // Since it's only intended to be used from the SessionProvider in a thread-safe manner, that'll be okay
    public class JsonFileSessionRepository : ISessionRepository
    {
        private readonly string _directory;
        private readonly DateTimeUtcTimeStampProvider _timestampProvider;

        public JsonFileSessionRepository(string directory, DateTimeUtcTimeStampProvider timestampProvider)
        {
            this._directory = directory;
            this._timestampProvider = timestampProvider;
        }

        public async Task<HiRezApiSession> GetAsync(Platform platform)
        {
            return await this.LoadAsync(platform);
        }

        public Task RemoveAsync(Platform platform)
        {
            File.Delete(this.GetFilePath(platform));
            return Task.CompletedTask;
        }

        public async Task SetAsync(HiRezApiSession session)
        {
            await this.SaveAsync(session);
        }

        private string GetFilePath(Platform platform)
        {
            return Path.Combine(this._directory, $"session_{platform}.json");
        }

        private async Task<HiRezApiSession> LoadAsync(Platform platform)
        {
            var filePath = this.GetFilePath(platform);
            if (!File.Exists(filePath))
                return null;

            using (var sr = new StreamReader(filePath, Encoding.UTF8))
            {
                var str = await sr.ReadToEndAsync();
                var session = JsonConvert.DeserializeObject<HiRezApiSession>(str);
                session.TimeStampProvider = this._timestampProvider;
                if (session.IsValid) return session;
            }

            return null;
        }

        private async Task SaveAsync(HiRezApiSession session)
        {
            var filePath = this.GetFilePath(session.Platform);
            using (var sw = new StreamWriter(filePath, false, Encoding.UTF8)) await sw.WriteAsync(JsonConvert.SerializeObject(session));
        }
    }
}