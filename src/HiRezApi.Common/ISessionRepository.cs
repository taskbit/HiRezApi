namespace HiRezApi.Common
{
    using System.Threading.Tasks;

    public interface ISessionRepository
    {
        Task<HiRezApiSession> GetAsync(Platform platform);
        Task RemoveAsync(Platform platform);
        Task SetAsync(HiRezApiSession session);
    }
}