using Contracts.IRepositories;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly Container _container;
        protected readonly CosmosDbContext _dbContext;

        public RepositoryBase(CosmosDbContext dbContext, string containerName)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

            if (string.IsNullOrEmpty(containerName))
            {
                throw new ArgumentNullException(nameof(containerName));
            }
            _container = _dbContext.GetContainerAsync(containerName).GetAwaiter().GetResult();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var query = _container.GetItemQueryIterator<T>();
            var results = new List<T>();

            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }

            return results;
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            try
            {
                var response = await _container.ReadItemAsync<T>(id.ToString(), new PartitionKey(id.ToString()));
                return response.Resource;
            }
            catch (CosmosException e) when (e.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task AddAsync(T entity)
        {
            await _container.CreateItemAsync(entity, new PartitionKey((entity as dynamic).Id));
        }

        public async Task UpdateAsync(T entity)
        {
            await _container.UpsertItemAsync(entity, new PartitionKey((entity as dynamic).Id));
        }

        public async Task DeleteAsync(Guid id)
        {
            await _container.DeleteItemAsync<T>(id.ToString(), new PartitionKey(id.ToString()));
        }

        public async Task<IEnumerable<T>> GetEntitiesByTypeAsync(string typeProperty, string typeValue)
        {
            var query = new QueryDefinition($"SELECT * FROM c WHERE c.{typeProperty} = @typeValue")
                .WithParameter("@typeValue", typeValue);
            var iterator = _container.GetItemQueryIterator<T>(query);
            var results = new List<T>();

            while (iterator.HasMoreResults)
            {
                var response = await iterator.ReadNextAsync();
                results.AddRange(response.ToList());
            }

            return results;
        }
    }
}
