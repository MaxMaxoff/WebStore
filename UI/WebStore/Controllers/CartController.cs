using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebStore.Domain.DTO.Order;
using WebStore.Domain.ViewModels.Details;
using WebStore.Domain.ViewModels.Order;
using WebStore.Interfaces.Services;

namespace WebStore.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _CartService;
        private readonly IOrderService _OrderService;

        public CartController(ICartService CartService, IOrderService OrderService)
        {
            _CartService = CartService;
            _OrderService = OrderService;
        }

        public IActionResult GetCartView()
        {
            return ViewComponent("Cart");
        }

        public IActionResult Details()
        {
            return View(new DetailsViewModel
            {
                CartViewModel = _CartService.TransformCart(),
                OrderViewModel = new OrderViewModel()
            });
        }

        public IActionResult DecrementFromCart(int id)
        {
            _CartService.DecrementFromCart(id);
            return Json(new { id, message = "Количество товара уменьшено на 1" });
        }

        public IActionResult RemoveFromCart(int id)
        {
            _CartService.RemoveFromCart(id);
            return Json(new { id, message = "Товар удалён из корзины" });
        }

        public IActionResult RemoveAll()
        {
            _CartService.RemoveAll();
            return RedirectToAction("Details");
        }

        public IActionResult AddToCart(int id)
        {
            _CartService.AddToCart(id);
            return Json(new { id, message = "Товар добавлен в корзину" });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult CheckOut(OrderViewModel model, [FromServices] ILogger<CartController> logger)
        {
            if (!ModelState.IsValid)
                return View("Details", new DetailsViewModel
                {
                    CartViewModel = _CartService.TransformCart(),
                    OrderViewModel = model
                });

            logger.LogInformation("Order CheckOut");

            var createOrderModel = new CreateOrderModel
            {
                OrderViewModel = model,
                Items = _CartService.TransformCart().Items.Select(item => new OrderItemDTO
                {
                    Id = item.Key.Id,
                    Quantity = item.Value
                }).ToList()
            };
            var order = _OrderService.CreateOrder(createOrderModel, User.Identity.Name);
            _CartService.RemoveAll();
            return RedirectToAction("OrderConfirmed", new { id = order.Id });
        }

        public IActionResult OrderConfirmed(int id)
        {
            ViewBag.Id = id;
            return View();
        }
    }
}