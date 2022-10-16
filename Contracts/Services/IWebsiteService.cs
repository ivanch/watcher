using Watcher.Models;

namespace Watcher.Contracts.Services
{
    public interface IWebsiteService
    {
        void AddWebsite(Website website);

        Task<List<Website>> GetWebsites();
    }
}
