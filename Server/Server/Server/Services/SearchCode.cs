using Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Server.Services
{
    public class SearchCode : ISearchCode
    {
        private readonly HttpClient _httpClient;

        public SearchCode(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<DeviceFlowAuth> GetCode(string clientId, string clientSecret)
        {
            var url = new Uri("https://allegro.pl/auth/oauth/device");
            var pOauth = GetAuthorizationParameters(clientId, clientSecret);
        

            HttpClient klient = new HttpClient();
            klient.DefaultRequestHeaders.Clear();
            klient.DefaultRequestHeaders.Add("Authorization", pOauth);
            klient.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("pl-PL"));

            var request = new HttpRequestMessage(HttpMethod.Post, "");
            var content = new StringContent("client_id=" + clientId, Encoding.UTF8, "application/x-www-form-urlencoded");
            var response =  await klient.PostAsync(url, content);

            response.EnsureSuccessStatusCode();
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var authResult = await JsonSerializer.DeserializeAsync<DeviceFlowAuth>(responseStream);

            return authResult;

        }
        public string GetAuthorizationParameters(string ClientID, string ClientSecretKey)
        {
            string headerAuthorization = ClientID + ":" + ClientSecretKey;
            byte[] bites = Encoding.UTF8.GetBytes(headerAuthorization);
            return "Basic " + Convert.ToBase64String(bites);
        }
    }
}