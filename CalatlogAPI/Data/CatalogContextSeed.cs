using CalatlogAPI.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace CalatlogAPI.Data
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool existProduct = productCollection.Find(s => true).Any();

            if (!existProduct)
            {
                productCollection.InsertManyAsync(GetPreconfiguredProduct());
            }
        }

        private static IEnumerable<Product> GetPreconfiguredProduct()
        {
            return new List<Product>
            {

               new Product{
                   Id="001",
                   Name = "Test1",
                   Summary="test Summary 1",
                   Category="test Category 1",
                   Description = "Description 1",
                   ImageFile = "test imagefile",
                   Path = ""

                }


            };
        }
    }
}