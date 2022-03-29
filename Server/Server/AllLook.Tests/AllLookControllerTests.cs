using Server.Controllers;
using AllLook.Database;
using Xunit;
using FakeItEasy;
using Moq;
using Server.Services;
using AllLook.Database.Interfaces;
using Server;
using Microsoft.Extensions.Options;
using Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Testing;
using AllLook.Database.Services;
using System;

namespace AllLook.Tests
{

    public class AllLookControllerTests
    {
        private IOptions<AllLookDatabaseSettings> _options;
        private IOptions<ClientSettings> _settings;
        private HttpClient _httpClient;

        public AllLookControllerTests()
        {
            AllLookDatabaseSettings sampleOptions = new AllLookDatabaseSettings() { ConnectionString = "mongodb+srv://darek:darek123@alllookdatabase.em2k8.mongodb.net/AllLook?retryWrites=true&w=majority", DatabaseName = "AllLook", TokenCollectionName = "Token", DeviceFlowAuthorizationCollectionName = "DeviceFlowAuthorization", ProductsCollectionName = "Products" };
            _options = Microsoft.Extensions.Options.Options.Create(sampleOptions);

            ClientSettings sampleSettings = new ClientSettings() { ClientId = "0f20f404a4e949979b8a1d631e0a3bee", ClientSecret = "7WDmIec4t3i6m5ngQOLwbI6PTnlGeyiqe2gruC7GgI9nFCi3nSWAJzFqj4xz3Ktn" };
            _settings = Microsoft.Extensions.Options.Options.Create(sampleSettings);

            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://api.allegro.pl");
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/vnd.allegro.public.v1+json");
        }
        [Fact]
        public async Task CheckEndpointHandlesEmptyApiResnonse()
        {
            var serviceDatabase = new DatabaseProductService(_options);
            var tokenService = new DatabaseTokenService(_options);
            var deviceService = new DatabaseDeviceFlowAuthorization(_options);
            var searchService = new SearchService(_httpClient);
            var allegroService = new AllegroService(_httpClient);
            var searchCode = new SearchCode(_httpClient);
            
            var searchServiceMock = new Mock<SearchService>(_httpClient);
            var allegroServiceMock = new Mock<AllegroService>(_httpClient);
            var searchCodeMock = new Mock<SearchCode>(_httpClient);


            var apiMock = new Mock<IDatabaseProductService>();
            apiMock.Setup(loader => loader.GetProductsCollection()).Returns(new List<Products>());

            var controller = new HomeController(searchService,
                                                allegroService,
                                                searchCode,
                                                _settings,
                                                deviceService,
                                                tokenService,
                                                serviceDatabase
                                                );

            var actionResponse = await controller.GetProducts("Laptop");
            Assert.Equal(30, actionResponse.Count);
            Assert.NotEmpty(actionResponse);

        }


    }
}
