using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace WebStore.Clients.Base
{
    /// <summary>
    /// Abstract class for Client
    /// </summary>
    public abstract class BaseClient
    {
        protected readonly HttpClient _Client;

        public string ServiceAddress { get; set; }

        protected BaseClient(IConfiguration configuration)
        {
            _Client = new HttpClient
            {
                BaseAddress = new Uri(configuration["ClientAddress"])
            };
            _Client.DefaultRequestHeaders.Accept.Clear();
            _Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        protected T Get<T>(string url) where T : new() => GetAsync<T>(url).Result;

        protected async Task<T> GetAsync<T>(string url, CancellationToken cancell = default(CancellationToken))
            where T : new()
        {
            var response = await _Client.GetAsync(url,cancell);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<T>(cancell);
            return default(T);
        }

        protected HttpResponseMessage Post<T>(string url, T value) where T : new() => 
            PostAsync(url, value).Result;
        
        protected async Task<HttpResponseMessage> PostAsync<T>(string url, T value, CancellationToken cancell = default(CancellationToken))
            where T : new()
        {
            var response = await _Client.PostAsJsonAsync(url, value, cancell);
            return response.EnsureSuccessStatusCode();
        }

        protected HttpResponseMessage Put<T>(string url, T value) where T : new() => PutAsync(url, value).Result;
        
        protected async Task<HttpResponseMessage> PutAsync<T>(string url, T value, CancellationToken cancell = default(CancellationToken))
            where T : new() => 
            (await _Client.PutAsJsonAsync(url, value, cancell)).EnsureSuccessStatusCode();

        protected HttpResponseMessage Delete(string url) =>
            DeleteAsync(url).Result;

        protected async Task<HttpResponseMessage> DeleteAsync(string url,
            CancellationToken cancell = default(CancellationToken)) =>
            await _Client.DeleteAsync(url, cancell);
    }
}
