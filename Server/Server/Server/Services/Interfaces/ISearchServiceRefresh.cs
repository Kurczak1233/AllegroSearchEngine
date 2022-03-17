using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Services
{
   public interface ISearchServiceRefresh
    {
        public Task<Token> GetRefreshToken(string token, string ClientId, string ClientSecret);

        public Task<Token> GetAccessTokenByRefreshToken(string ClientId, string ClientSecret, string RefreshToken);
    }
}
