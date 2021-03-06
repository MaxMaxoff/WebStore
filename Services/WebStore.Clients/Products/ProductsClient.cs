﻿using System.Collections.Generic;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using WebStore.Clients.Base;
using WebStore.Domain.DTO.Product;
using WebStore.Domain.Entities;
using WebStore.Interfaces.Services;

namespace WebStore.Clients.Products
{
    public class ProductsClient : BaseClient, IProductData
    {
        public ProductsClient(IConfiguration configuration) : base(configuration) =>
            ServiceAddress = "api/Products";

        public IEnumerable<Section> GetSections() => Get<List<Section>>($"{ServiceAddress}/sections");

        public Section GetSectionById(int id) => Get<Section>($"{ServiceAddress}/sections/{id}");

        public IEnumerable<Brand> GetBrands() => Get<List<Brand>>($"{ServiceAddress}/brands");

        public Brand GetBrandById(int id) => Get<Brand>($"{ServiceAddress}/brands/{id}");

        //public IEnumerable<ProductDTO> GetProducts(ProductFilter Filter = null)
        public PagedProductDTO GetProducts(ProductFilter Filter = null)
        {
            //return Post(ServiceAddress, Filter).Content.ReadAsAsync<IEnumerable<ProductDTO>>().Result;
            return Post(ServiceAddress, Filter).Content.ReadAsAsync<PagedProductDTO>().Result;
        }

        public ProductDTO GetProductById(int id) => Get<ProductDTO>($"{ServiceAddress}/{id}");
    }
}
