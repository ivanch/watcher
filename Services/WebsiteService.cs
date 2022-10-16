using Watcher.Contracts.Repository;
using Watcher.Contracts.Services;
using Watcher.Models;

namespace Watcher.Services
{
    public class WebsiteService : IWebsiteService
    {
        private readonly IWebsiteRepository websiteRepository;

        public WebsiteService(IWebsiteRepository websiteRepository)
        {
            this.websiteRepository = websiteRepository;
        }

        public void AddWebsite(Website website)
        {
            websiteRepository.SaveWebsite(website);
        }

        public Task<List<Website>> GetWebsites()
        {
            string user = "default";
            return websiteRepository.GetWebsites(user);
        }
    }
}
