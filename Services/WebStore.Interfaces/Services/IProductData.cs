using System.Collections.Generic;
using WebStore.Domain.DTO.Product;
using WebStore.Domain.Entities;

namespace WebStore.Interfaces.Services
{
    /// <summary>
    /// Interface for Product Data
    /// </summary>
    public interface IProductData
    {
        IEnumerable<Brand> GetBrands();

        Brand GetBrandById(int id);

        IEnumerable<Section> GetSections();

        Section GetSectionById(int id);

        IEnumerable<ProductDTO> GetProducts(ProductFilter Filter = null);

        ProductDTO GetProductById(int id);
    }
}