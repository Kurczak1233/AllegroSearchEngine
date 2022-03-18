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
   
        public class SearchService : ISearchService
        {
            private readonly HttpClient _httpClient;

            public SearchService(HttpClient httpClient)
            {
                _httpClient = httpClient;
            }
            
            public string GetAuthorizationParameters(string ClientID, string ClientSecretKey)
            {
                string headerAuthorization = ClientID + ":" + ClientSecretKey;
                byte[] bites = Encoding.UTF8.GetBytes(headerAuthorization);
                return "Basic " + Convert.ToBase64String(bites);
            }

            public async Task<Token> GetToken(string deviceCode,string clientId,string clientSecret)
            {
                var url = new Uri($"https://allegro.pl/auth/oauth/token?grant_type=urn%3Aietf%3Aparams%3Aoauth%3Agrant-type%3Adevice_code&device_code={deviceCode}");

                // var content = new StringContent($"grant_type=urn%3Aietf%3Aparams%3Aoauth%3Agrant-type%3Adevice_code&device_code={deviceCode}", Encoding.UTF8, "application/x-www-form-urlencoded");

            //var request = new HttpRequestMessage(HttpMethod.Post, "");

            //request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/x-www-form-urlencoded"));
            //request.Headers.Authorization = new AuthenticationHeaderValue(
            //    "Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}")));
            //request.Content = new FormUrlEncodedContent(new Dictionary<string, string>
            //{
            //    {"grant_type", "urn%3Aietf%3Aparams%3Aoauth%3Agrant-type%3Adevice_code"},
            //    {"device_code", $"{deviceCode}"}
            //});

            //var response = await _httpClient.SendAsync(request);
           
            var pOauth = GetAuthorizationParameters(clientId, clientSecret);


            HttpClient klient = new HttpClient();
            klient.DefaultRequestHeaders.Clear();
            klient.DefaultRequestHeaders.Add("Authorization", pOauth);
            klient.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("pl-PL"));

            var request = new HttpRequestMessage(HttpMethod.Post, "");
            var content = new StringContent("", Encoding.UTF8, "application/x-www-form-urlencoded");
            var response = await klient.PostAsync(url, content);

            response.EnsureSuccessStatusCode();
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var authResult = await JsonSerializer.DeserializeAsync<Token>(responseStream);
            authResult.ExpiredDateTime = DateTime.Now.AddSeconds(authResult.expires_in);

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
                authResult.ExpiredDateTime = DateTime.Now.AddSeconds(authResult.expires_in);
                return authResult;
            }
        }
    
}
