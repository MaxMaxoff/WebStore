using WebStore.Domain.ViewModels.Cart;

namespace WebStore.Interfaces.Services
{
    /// <summary>
    /// Interface for Cart Service
    /// 
    /// </summary>
    public interface ICartService
    {
        void DecrementFromCart(int id);
        void RemoveFromCart(int id);
        void RemoveAll();
        void AddToCart(int id);
        CartViewModel TransformCart();
    }
}
