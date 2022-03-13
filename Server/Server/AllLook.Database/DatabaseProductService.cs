using Microsoft.Extensions.Options;
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
        private readonly IMongoCollection<Product> _products;
        public DatabaseProductService(IOptions<AllLookDatabaseSettings> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            _products = mongoClient.GetDatabase(options.Value.DatabaseName)
                .GetCollection<Product>(options.Value.ProductsCollectionName);

        }




        public List<Product> GetProductsCollection() => _products.Find(product=>true).ToList();
        
    }
}
