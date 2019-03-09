﻿using System.Collections.Generic;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using WebStore.Clients.Base;
using WebStore.Domain.DTO;
using WebStore.Domain.Entities;
using WebStore.Interfaces.Services;

namespace WebStore.Clients.Products
{
    public class ProductsClient : BaseClient, IProductData
    {
        public ProductsClient(IConfiguration configuration) : base(configuration) => 
            ServiceAddress = "api/Products";

        public IEnumerable<Brand> GetBrands()
        {
            return Get<List<Brand>>($"{ServiceAddress}/brands");
        }

        public IEnumerable<Section> GetSections()
        {
            return Get<List<Section>>($"{ServiceAddress}/sections");
        }

        public IEnumerable<ProductDTO> GetProducts(ProductFilter Filter = null)
        {
            var response = Post(ServiceAddress, Filter);
            return response.Content.ReadAsAsync<IEnumerable<ProductDTO>>().Result;
        }

        public ProductDTO GetProductById(int id) => 
            Get<ProductDTO>($"{ServiceAddress}/{id}");
    }
}
