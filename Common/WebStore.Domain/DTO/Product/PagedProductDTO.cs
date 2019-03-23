using System.Collections.Generic;

namespace WebStore.Domain.DTO.Product
{
    public class PagedProductDTO
    {
        public IEnumerable<ProductDTO> Products { get; set; }

        public int TotalCount { get; set; }
    }
}