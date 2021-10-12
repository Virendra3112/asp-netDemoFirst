using CalatlogAPI.Entities;
using MongoDB.Driver;

namespace CalatlogAPI.Data
{
    public interface ICatalogContext
    {
        IMongoCollection<Product> Products { get; }
    }
}
