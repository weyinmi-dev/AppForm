using Microsoft.Azure.Cosmos;
using Repository;

namespace ApplicationForm.DataMigration
{
    public class DataMigrationService
    {
        private readonly Container _container;

        public DataMigrationService(CosmosDbContext dbContext, string containerName)
        {
            _container = dbContext.GetContainerAsync(containerName).Result;
        }

        public async Task MigrateDataAsync()
        {
            var query = _container.GetItemQueryIterator<dynamic>("SELECT * FROM c");
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                foreach (var item in response)
                {
                    // Apply transformation to item as needed
                    item.NewField = item.OldField;
                    await _container.UpsertItemAsync(item, new PartitionKey(item.id.ToString()));
                }
            }
        }
    }
}
