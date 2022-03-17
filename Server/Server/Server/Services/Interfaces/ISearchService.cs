using Models;
using System.Threading.Tasks;

namespace Server.Services
{
    public interface ISearchService
    {
        Task<Token> GetToken(string deviceCode,string ClientId,string ClientSecret);
    }
}