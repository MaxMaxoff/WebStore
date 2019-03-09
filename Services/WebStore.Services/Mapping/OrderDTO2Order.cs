using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebStore.Domain.DTO.Order;
using WebStore.Domain.Entities;

namespace WebStore.Services.Mapping
{
    public static class OrderDTO2Order
    {
        public static OrderDTO Map(this Order order) =>
        new OrderDTO
        {
            Id = order.Id,
            Address = order.Address,
            Date = order.Date,
            Name = order.Name,
            Phone = order.Phone,
            Items = order.OrderItems?.Select(item => new OrderItemDTO
            {
                Id = item.Id,
                Price = item.Price,
                Quantity = item.Count,
            })

        };
    }
}
