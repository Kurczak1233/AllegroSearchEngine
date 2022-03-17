using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AllLook.Database;
using AllLook.Database.Interfaces;
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
        private readonly ISearchServiceRefresh _searchServiceRefresh;
        private readonly ISearchCode _searchCode;
        private readonly IDatabaseDeviceFlowAuthorization _deviceFlowAuth;
        private readonly IDatabaseTokenService _databaseTokenService;
        private readonly IDatabaseProductService _databaseProductService;

        private readonly IOptions<ClientSettings> _client;
    
      
        


        public HomeController(ISearchService searchService,
            IAllegroService allegroService,
            ISearchCode searchCode,
            ISearchServiceRefresh searchServiceRefresh,
            IOptions<ClientSettings> options,
            IDatabaseDeviceFlowAuthorization deviceFlowAuth,
             IDatabaseTokenService databaseTokenService,
             IDatabaseProductService databaseProductService
            )
        {
            _searchService = searchService;
            _allegroService = allegroService;
            _searchCode = searchCode;
            _searchServiceRefresh = searchServiceRefresh;
            _client = options;
            _deviceFlowAuth = deviceFlowAuth;
            _databaseTokenService = databaseTokenService;
            _databaseProductService = databaseProductService;
        }


        [HttpGet(nameof(GetAuthorization))]
        public async Task<string> GetAuthorization()
        {
            var DeviceFlowAuth = await _searchCode.GetCode(_client.Value.ClientId,_client.Value.ClientSecret);
              _deviceFlowAuth.DropDeviceFlowAuth();
             _deviceFlowAuth.AddDeviceFlowAuth(DeviceFlowAuth);
           

            return DeviceFlowAuth.verification_uri_complete;


        }
        [HttpGet(nameof(GetRefreshToken))]
        public async Task<Token> GetRefreshToken()
        {
            Token _token = _databaseTokenService.GetToken();
            var newToken = await _searchServiceRefresh.GetRefreshToken(_token.refresh_token, _client.Value.ClientId, _client.Value.ClientSecret);
            _databaseTokenService.DropToken();
            _databaseTokenService.AddToken(newToken);
            return newToken;


        }

        //[HttpGet(nameof(GetCategories))]

        //public async Task<IEnumerable<Categories>> GetCategories()
        //{
        //    var token = await _searchService.GetToken(_code, _client.Value.ClientId, _client.Value.ClientSecret);
        //    var newCategories = await _allegroService.GetCategories(token.access_token);
        //    return newCategories;
        //}

        [HttpGet(nameof(GetProducts))]

        public async Task<List<Products>> GetProducts(string phrase)
        {

            Token _token = _databaseTokenService.GetToken();


            var newProducts = await _allegroService.GetProducts(phrase, _token.access_token);
            _databaseProductService.DropProductsCollection();
            _databaseProductService.AddProductsCollection(newProducts.ToList());

            return newProducts.ToList();
        }


        [HttpGet(nameof(GetToken))]

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