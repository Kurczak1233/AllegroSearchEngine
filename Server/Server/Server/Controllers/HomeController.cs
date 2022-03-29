using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using AllLook.Database;
using AllLook.Database.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Models;
using Server.Services;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ISearchService _searchService;
        private readonly IAllegroService _allegroService;
        private readonly ISearchCode _searchCode;
        private readonly IDatabaseDeviceFlowAuthorization _deviceFlowAuth;
        private readonly IDatabaseTokenService _databaseTokenService;
        private readonly IDatabaseProductService _databaseProductService;
        private readonly IOptions<ClientSettings> _client;

        public HomeController(ISearchService searchService,
            IAllegroService allegroService,
            ISearchCode searchCode,
            IOptions<ClientSettings> options,
            IDatabaseDeviceFlowAuthorization deviceFlowAuth,
            IDatabaseTokenService databaseTokenService,
            IDatabaseProductService databaseProductService

        )
        {
            _searchService = searchService;
            _allegroService = allegroService;
            _searchCode = searchCode;
            _client = options;
            _deviceFlowAuth = deviceFlowAuth;
            _databaseTokenService = databaseTokenService;
            _databaseProductService = databaseProductService;

        }

        [HttpGet("GetAuthorization")]
        public async Task<string> GetAuthorization()
        {
            var DeviceFlowAuth = await _searchCode.GetCode(_client.Value.ClientId,_client.Value.ClientSecret);
              _deviceFlowAuth.DropDeviceFlowAuth();
             _deviceFlowAuth.AddDeviceFlowAuth(DeviceFlowAuth);
             
            return DeviceFlowAuth.verification_uri_complete;
        }

        [HttpGet("GetAccessTokenByRefreshToken/")]
        public async Task<Token> GetAccessTokenByRefreshToken()
        {
            Token _token = _databaseTokenService.GetToken();
          
            var newToken = await _searchService.GetAccessTokenByRefreshToken(_client.Value.ClientId, _client.Value.ClientSecret, _token.refresh_token);
            _databaseTokenService.DropToken();
            _databaseTokenService.AddToken(newToken);
            return newToken;
        }
        internal async void ReplaceDataInDatabase(IEnumerable<Products> products)
        {
            _databaseProductService.DropProductsCollection();
            _databaseProductService.AddProductsCollection(products.ToList());
        }

        [HttpGet("GetProducts/{phrase}")]
        public async Task<List<Products>> GetProducts(string phrase)
        {
            Token _token = _databaseTokenService.GetToken();
            var newProducts = await _allegroService.GetProducts(phrase, _token.access_token);
            
            if (_token.ExpiredDateTime > DateTime.Now)
            {
                ReplaceDataInDatabase(newProducts);
                return newProducts.ToList();
            }
            else
            {
                await GetAccessTokenByRefreshToken();
                ReplaceDataInDatabase(newProducts);
                return newProducts.ToList();
            }
        }


        [HttpGet("GetToken/")]

        public async Task<Token> GetToken()
        {
            Token _token;
            
            string _deviceCode = _deviceFlowAuth.GetDeviceCode();
            _token = await _searchService.GetToken(_deviceCode, _client.Value.ClientId, _client.Value.ClientSecret);
            _databaseTokenService.DropToken();
            _databaseTokenService.AddToken(_token);

            return _token;
        }

    }
}