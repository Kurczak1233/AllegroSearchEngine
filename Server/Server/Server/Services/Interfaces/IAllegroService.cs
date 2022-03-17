using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Services
{
    public interface IAllegroService
    {
        Task<IEnumerable<Categories>> GetCategories(string token);
        Task<IEnumerable<Products>> GetProducts(string phrase, string access_token);
    }
}