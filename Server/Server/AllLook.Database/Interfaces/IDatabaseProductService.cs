using Models;
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
      public  List<Products> GetProductsCollection();

        public void DropProductsCollection();
        public void AddProductsCollection(List<Products> newProducts);
    }
}
