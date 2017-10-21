namespace HiRezApi.Common
{
    using System.Threading.Tasks;

    public interface ISessionProvider
    {
        Task<HiRezApiSession> AcquireAsync();

        Task ClearAsync();

        void ProvideClient(IHiRezApiClient client);
    }
}