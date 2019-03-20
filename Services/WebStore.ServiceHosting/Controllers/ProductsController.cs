using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebStore.Domain.DTO.Product;
using WebStore.Domain.Entities;
using WebStore.Interfaces.Services;

namespace WebStore.ServiceHosting.Controllers
{
    /// <summary>
    /// Controller for Products
    /// Looks like proxy
    /// </summary>
    [ApiController, Route("api/[controller]"), Produces("application/json")]
    public class ProductsController : ControllerBase, IProductData
    {
        private readonly IProductData _ProductData;

        public ProductsController(IProductData ProductData) => _ProductData = ProductData;

        /// <summary>
        /// Http Get Method
        /// </summary>
        /// <returns>List of Brands</returns>
        [HttpGet("brands")]
        public IEnumerable<Brand> GetBrands()
        {
            return _ProductData.GetBrands();
        }

        [HttpGet("brands/{id}")]
        public Brand GetBrandById(int id) => _ProductData.GetBrandById(id);

        /// <summary>
        /// Http Get Method
        /// </summary>
        /// <returns>List of Section</returns>
        [HttpGet("sections")]
        public IEnumerable<Section> GetSections()
        {
            return _ProductData.GetSections();
        }

        [HttpGet("sections/{id}")]
        public Section GetSectionById(int id) => _ProductData.GetSectionById(id);

        /// <summary>
        /// Http Get Method
        /// </summary>
        /// <param name="Filter">filter by product</param>
        /// <returns>List of Products</returns>
        [HttpPost, ActionName("Post")]
        public IEnumerable<ProductDTO> GetProducts([FromBody] ProductFilter Filter = null)
        {
            return _ProductData.GetProducts(Filter);
        }

        /// <summary>
        /// Http Get Method
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>Product </returns>
        [HttpGet("{id}"), ActionName("Get")]
        public ProductDTO GetProductById(int id)
        {
            return _ProductData.GetProductById(id);
        }
    }
}