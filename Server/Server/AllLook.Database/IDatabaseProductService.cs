using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllLook.Database
{
    public interface IDatabaseProductService
    {
      public  List<Product> GetProductsCollection();
    }
}
