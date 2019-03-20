using WebStore.Domain.DTO.Product;
using WebStore.Domain.Entities;

namespace WebStore.Services.Mapping
{
    public static class ProductDTO2Product
    {
        public static ProductDTO Map(this Product product)
        {
            return new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                Order = product.Order,
                Brand = product.Brand is null
                    ? null
                    : new BrandDTO
                    {
                        Id = product.Brand.Id,
                        Name = product.Brand.Name
                    }
            };
        }
    }
}
