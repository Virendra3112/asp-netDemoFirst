using CalatlogAPI.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace CalatlogAPI.Data
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabseSettings:ConnectionString"));

            var database = client.GetDatabase(configuration.GetValue<string>("DatabseSettings:DatabaseName"));

            Products = database.GetCollection<Product>(configuration.GetValue<string>("DatabseSettings:CollectionName"));

            CatalogContextSeed.SeedData(Products);
        
        }
        public IMongoCollection<Product> Products { get; set; }
    }
}
