using System.Collections.Generic;
using WebStore.Domain.Entities;
using WebStore.Domain.ViewModels.Cart;
using WebStore.Domain.ViewModels.Order;

namespace WebStore.Interfaces
{
    /// <summary>
    /// Interface for Order Service
    /// </summary>
    public interface IOrderService
    {
        IEnumerable<Order> GetUserOrders(string UserName);

        Order GetOrderById(int id);

        Order CreateOrder(OrderViewModel OrderModel, CartViewModel CartModel, string UserName);
    }
}
