using Nest;
using Elasticsearch.Net;

namespace N5.Permissions.Application
{
    /// <summary>
    /// Developer: Johans Cuellar
    /// Date: 02/19/2025
    /// </summary>
    public class Elasticsearch
    {
        public async Task<bool> AddOrUpdate<T>(T document, string indexName) where T : class
        {
            var connectionSettings = new ConnectionSettings(new Uri("http://localhost:9200")).EnableApiVersioningHeader();
            var client = new ElasticClient(connectionSettings);

            if (!client.Indices.Exists(indexName).Exists)
            {
                await client.Indices.CreateAsync(indexName, c => c.Map<dynamic>(m => m.AutoMap()));
            }

            var indexResponse = await client.IndexAsync(document, idx => idx.Index(indexName).OpType(OpType.Index));
            return indexResponse.IsValid;
        }
    }
}
