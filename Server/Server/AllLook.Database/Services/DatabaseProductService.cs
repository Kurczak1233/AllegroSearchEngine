using Microsoft.Extensions.Options;
using Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllLook.Database
{
    public class DatabaseProductService : IDatabaseProductService
    {
        private readonly IMongoCollection<Products> _products;
        public DatabaseProductService(IOptions<AllLookDatabaseSettings> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            _products = mongoClient.GetDatabase(options.Value.DatabaseName)
                .GetCollection<Products>(options.Value.ProductsCollectionName);

        }




        public List<Products> GetProductsCollection() => _products.Find(product=>true).ToList();
        public void DropProductsCollection() => _products.DeleteMany(x=>true);
        public void AddProductsCollection(List<Products> newProducts) => _products.InsertMany(newProducts);

    }
}
