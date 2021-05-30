
using System.Collections.Generic;
using System.Threading.Tasks;
using AuditTool.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AuditTool.Repositories
{
    public class EngagementRepository : IEngagementRepository
    {
        private readonly CosmosClient client;
        private readonly ILogger<EngagementRepository> logger;
        private readonly Container container;

        public EngagementRepository(CosmosClient client, IConfiguration config, ILogger<EngagementRepository> logger)
        {
            this.client = client;
            this.logger = logger;
            this.container = client.GetContainer(config.GetSection("CosmosDb").GetSection("DatabaseName").Value, config.GetSection("CosmosDb").GetSection("ContainerName").Value);
        }

        public async Task AddAsync(Engagement item)
        {
            await this.container.CreateItemAsync<Engagement>(item, new PartitionKey(item.Id));

        }

        public async Task DeleteAsync(string id, string partitionKey)
        {
            await this.container.DeleteItemAsync<Engagement>(id, new PartitionKey(partitionKey));
        }

        public async Task<IEnumerable<Engagement>> GetAllAsync()
        {
            var results = new List<Engagement>();
            var query = this.container.GetItemQueryIterator<Engagement>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();

                results.AddRange(response.Resource);
            }

            return results;
        }

        public async Task<Engagement> GetAsync(string id, string partitionKey)
        {
            try
            {
                ItemResponse<Engagement> response = await this.container.ReadItemAsync<Engagement>(id, new PartitionKey(partitionKey));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }


        public async Task<Engagement> ReplaceAsync(Engagement item)
        {
            throw new System.NotImplementedException();
        }
    }
}