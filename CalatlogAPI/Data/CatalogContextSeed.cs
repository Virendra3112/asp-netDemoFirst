using CalatlogAPI.Entities;
using MongoDB.Driver;
using System;

namespace CalatlogAPI.Data
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            if (productCollection != null)
            {

            }
        }
    }
}