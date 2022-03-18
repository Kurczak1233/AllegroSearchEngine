using Models;
using System.Threading.Tasks;

namespace Server.Services
{
    public interface ISearchService
    {
        Task<Token> GetToken(string deviceCode,string ClientId,string ClientSecret);
        string GetAuthorizationParameters(string ClientID, string ClientSecretKey);
        Task<Token> GetAccessTokenByRefreshToken(string ClientId, string ClientSecret, string RefreshToken);
    }
}