using WebStore.Domain.ViewModels.Cart;
using WebStore.Domain.ViewModels.Order;

namespace WebStore.Domain.ViewModels.Details
{
    public class DetailsViewModel
    {
        public CartViewModel CartViewModel { get; set; }

        public OrderViewModel OrderViewModel { get; set; }
    }
}
