using WebStore.Domain.DTO;
using WebStore.Domain.Entities;

namespace WebStore.Services.Mapping
{
    public static class BrandDTO2Brand
    {
        public static BrandDTO Map(this Brand brand)
        {
            return new BrandDTO
            {
                Id = brand.Id,
                Name = brand.Name,
            };
        }
    }
}

