using MongoDB.Driver;
using Watcher.Contracts.Repository;
using Watcher.Models;

namespace Watcher.Repository
{
    public class WebsiteRepository : IWebsiteRepository
    {
        private readonly IMongoDatabase database;
        private readonly IMongoCollection<Website> collection;

        public WebsiteRepository()
        {
            var client = new MongoClient(
                "mongodb://watcher:HiJSywpo3Z6SPPDM@ac-s7mygue-shard-00-00.sgwa8kk.mongodb.net:27017,ac-s7mygue-shard-00-01.sgwa8kk.mongodb.net:27017,ac-s7mygue-shard-00-02.sgwa8kk.mongodb.net:27017/?ssl=true&replicaSet=atlas-bqcgmn-shard-0&authSource=admin&retryWrites=true&w=majority"
            );
            database = client.GetDatabase("watcher");

            collection = database.GetCollection<Website>("websites");
        }

        public async void SaveWebsite(Website website)
        {
            await collection.InsertOneAsync(website);
        }

        public async Task<List<Website>> GetWebsites(string user)
        {
            var result = await collection.FindAsync(m => m.User == user);
            
            return result.ToList();
        }

    }
}
