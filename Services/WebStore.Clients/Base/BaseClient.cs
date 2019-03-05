using System;
using System.Net.Http;
using System.Net.Http.Headers;
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
    }
}
