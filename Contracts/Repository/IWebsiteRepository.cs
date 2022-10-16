using Watcher.Models;

namespace Watcher.Contracts.Repository
{
    public interface IWebsiteRepository
    {
        void SaveWebsite(Website website);
        Task<List<Website>> GetWebsites(string user);
    }
}
