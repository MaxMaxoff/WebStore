using Microsoft.AspNetCore.Mvc;
using WebStore.Interfaces.Api;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
         
        public IActionResult ContactUs() => View();

        public IActionResult Cart() => View();

        public IActionResult BlogSingle() => View();

        public IActionResult Blog() => View();

        public IActionResult ErrorPage404() => View();

        public IActionResult ErrorStatus(string errorCode)
        {
            switch (errorCode)
            {
                case "404":
                    return RedirectToAction(nameof(ErrorPage404));
                default:
                    return Content($"Error code {errorCode}");
            }
        }

        public IActionResult ValuesServiceTest([FromServices] IValuesService ValuesService) => 
            View(ValuesService.Get());
    }
}