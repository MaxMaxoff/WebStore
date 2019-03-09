﻿using WebStore.Domain.Entities.Base.Interfaces;

namespace WebStore.Domain.DTO.Product
{
    public class BrandDTO : INamedEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
