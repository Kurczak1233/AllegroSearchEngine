using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Server.Services
{
    public class SearchServiceRefresh : ISearchServiceRefresh
    {
        private readonly HttpClient _httpClient;

        public SearchServiceRefresh(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Token> GetRefreshToken(string refresh_token,string clientId,string clientSecret)
        {
            var pOauth = GetAuthorizationParameters(clientId, clientSecret);
            var url = new Uri($"https://allegro.pl/auth/oauth/token?grant_type=refresh_token&refresh_token={refresh_token}");


            HttpClient klient = new HttpClient();
            klient.DefaultRequestHeaders.Clear();
            klient.DefaultRequestHeaders.Add("Authorization", pOauth);
        

            var request = new HttpRequestMessage(HttpMethod.Post, "");
            var content = new StringContent("", Encoding.UTF8, "application/x-www-form-urlencoded");
            var response = await klient.PostAsync(url, content);

            response.EnsureSuccessStatusCode();
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var authResult = await JsonSerializer.DeserializeAsync<Token>(responseStream);
            return authResult;
        }
        
        public async Task<Token> GetAccessTokenByRefreshToken(string clientId, string clientSecret, string refreshToken)
        {
            var url = new Uri($"https://allegro.pl/auth/oauth/token?grant_type=refresh_token&refresh_token={refreshToken}&redirect_uri=https://localhost:5000");
            var p0auth = GetAuthorizationParameters(clientId, clientSecret);
            
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Authorization", p0auth);
            
            var content = new StringContent("", Encoding.UTF8, "application/x-ww-form-urlencoded");
            var response = await _httpClient.PostAsync(url, content);

            response.EnsureSuccessStatusCode();
            
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var authResult = await JsonSerializer.DeserializeAsync<Token>(responseStream);
            
            return authResult;
        }
        private string GetAuthorizationParameters(string idKlienta, string sekretneIdKlienta)
        {
            string idks = idKlienta + ":" + sekretneIdKlienta;
            byte[] bajty = Encoding.UTF8.GetBytes(idks);
            return "Basic " + Convert.ToBase64String(bajty);
        }
    }
}
