using Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace Server.Services
{
    public class AllegroService : IAllegroService
    {
        private readonly HttpClient _httpClient;

        public AllegroService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Categories>> GetCategories(string access_token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", access_token);

            var response = await _httpClient.GetAsync($"/sale/categories");

            using var responseStream = await response.Content.ReadAsStreamAsync();

            var responseObject = await JsonSerializer.DeserializeAsync<GetCategoriesResult>(responseStream);

            return responseObject?.categories?.Select(i => new Categories()
            {
                Id = i.id,
                Leaf = i.leaf,
                Name = i.name,
                Options = i.options,
                Parent = i.parent
            });

        }

        public async Task<IEnumerable<Products>> GetProducts(string phrase, string access_token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", access_token);

            var response = await _httpClient.GetAsync($"/sale/products?phrase={phrase}");

            using var responseStream = await response.Content.ReadAsStreamAsync();

            var responseObject = await JsonSerializer.DeserializeAsync<GetProductsResult>(responseStream);
            List<Parameter> mainParam = responseObject?.products.Select(x => x.parameters.Where(x => x.rangeValue is null )).FirstOrDefault().ToList();
            // List<Parameter> mainParam = responseObject?.products.Select(x => x.parameters.First()).ToList();
            

            return responseObject?.products?.Select(i => new Products()
            {
                Id = i.id,
                Name = i.name,
                Category = i.category.id,
                Images = i.images.Select(x => x.url).FirstOrDefault(),
                Parameters = i.parameters.Where(x=>x.id == mainParam.Select(x=>x.id).FirstOrDefault()|| x.id == mainParam.Select(x => x.id).Reverse().FirstOrDefault()).ToList()
                
            });
         

        }

    }
}