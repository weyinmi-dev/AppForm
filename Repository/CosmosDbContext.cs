using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CosmosDbContext
    {
        private readonly CosmosClient _cosmosClient;
        private readonly Database _database;

        public CosmosDbContext(IConfiguration configuration)
        {
            var account = configuration["CosmosDb:Account"];
            var key = configuration["CosmosDb:Key"];
            var databaseName = configuration["CosmosDb:DatabaseName"];

            if (string.IsNullOrEmpty(account) || string.IsNullOrEmpty(key) || string.IsNullOrEmpty(databaseName))
            {
                throw new ArgumentNullException("Cosmos DB configuration is missing required fields.");
            }

            _cosmosClient = new CosmosClient(account, key);
            _database = _cosmosClient.GetDatabase(databaseName);
        }

        public async Task<Container> GetContainerAsync(string containerName)
        {
            try
            {
                if (string.IsNullOrEmpty(containerName))
                {
                    throw new ArgumentNullException(nameof(containerName));
                }
                return await _database.CreateContainerIfNotExistsAsync(containerName, "/id");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
