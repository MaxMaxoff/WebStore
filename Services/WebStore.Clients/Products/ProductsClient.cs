using System.Collections.Generic;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using WebStore.Clients.Base;
using WebStore.Domain.DTO;
using WebStore.Domain.DTO.Product;
using WebStore.Domain.Entities;
using WebStore.Interfaces.Services;

namespace WebStore.Clients.Products
{
    public class ProductsClient : BaseClient, IProductData
    {
        private readonly ILogger<ProductsClient> _Logger;

        public ProductsClient(IConfiguration configuration, ILogger<ProductsClient> Logger) : base(configuration)
        {
            _Logger = Logger;
            ServiceAddress = "api/Products";
        }

        public IEnumerable<Brand> GetBrands()
        {
            _Logger.LogInformation("Prepare Products Brands list");
            return Get<List<Brand>>($"{ServiceAddress}/brands");
        }

        public IEnumerable<Section> GetSections()
        {
            _Logger.LogInformation("Prepare Products Sections list");
            return Get<List<Section>>($"{ServiceAddress}/sections");
        }

        public IEnumerable<ProductDTO> GetProducts(ProductFilter Filter = null)
        {
            _Logger.LogInformation("Prepare Products list");
            var response = Post(ServiceAddress, Filter);
            return response.Content.ReadAsAsync<IEnumerable<ProductDTO>>().Result;
        }

        public ProductDTO GetProductById(int id) => 
            Get<ProductDTO>($"{ServiceAddress}/{id}");
    }
}
