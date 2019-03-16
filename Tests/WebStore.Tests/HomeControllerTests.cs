using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebStore.Controllers;
using WebStore.Interfaces.Api;

namespace WebStore.Tests
{
    [TestClass]
    public class HomeControllerTests
    {
        private HomeController _Controller;

        /// <summary>
        /// Initialize new HomeController for Test
        /// </summary>
        [TestInitialize]
        public void Initialize() => _Controller = new HomeController();

        /// <summary>
        /// Test for public IActionResult Index() => View();
        /// </summary>
        [TestMethod]
        public void Index_Returns_View()
        {
            var result = _Controller.Index();
            Xunit.Assert.IsType<ViewResult>(result);
        }

        /// <summary>
        /// Test for public IActionResult ValuesServiceTest([FromServices] IValuesService ValuesService)
        /// </summary>
        [TestMethod]
        public void ValuesServiceTest_Method_Returns_With_Values()
        {
            var data = new [] { "1", "2", "3" };
            var expected_count = data.Length;

            var value_service_mock = new Mock<IValuesService>();
            value_service_mock
                .Setup(s => s.Get())
                .Returns(data);


            var result = _Controller.ValuesServiceTest(value_service_mock.Object);

            var view_result = Xunit.Assert.IsType<ViewResult>(result);

            var model = Xunit.Assert.IsAssignableFrom<IEnumerable<string>>(view_result.ViewData.Model);

            var actual_count = model.Count();
            Xunit.Assert.Equal(expected_count, actual_count);
        }

        /// <summary>
        /// Test for public IActionResult ErrorPage404() => View();
        /// </summary>
        [TestMethod]
        public void ErrorStatus_404_Redirect_To_ErrorPage404()
        {
            var result = _Controller.ErrorStatus("404");

            var redirect_to_action_result = Xunit.Assert.IsType<RedirectToActionResult>(result);

            Xunit.Assert.Null(redirect_to_action_result.ControllerName);
            Xunit.Assert.Equal(nameof(HomeController.ErrorPage404), redirect_to_action_result.ActionName);
        }

        /// <summary>
        /// Test for public IActionResult ErrorStatus(string errorCode)
        /// </summary>
        [TestMethod]
        public void ErrorStatus_Another_Returns_Contens_Result()
        {
            var errorCode = "500";
            var expected_result = $"Error code {errorCode}";

            var result = _Controller.ErrorStatus(errorCode);

            var content_result = Xunit.Assert.IsType<ContentResult>(result);

            Xunit.Assert.Equal(expected_result, content_result.Content);
        }

        /// <summary>
        /// Test for public IActionResult ContactUs() => View();
        /// </summary>
        [TestMethod]
        public void ContactUs_Returns_View()
        {
            var result = _Controller.ContactUs();
            Xunit.Assert.IsType<ViewResult>(result);
        }

        /// <summary>
        /// Test for public IActionResult Cart() => View();
        /// </summary>
        [TestMethod]
        public void Cart_Returns_View()
        {
            var result = _Controller.Cart();
            Xunit.Assert.IsType<ViewResult>(result);
        }

        /// <summary>
        /// Test for public IActionResult BlogSingle() => View();
        /// </summary>
        [TestMethod]
        public void BlogSingle_Returns_View()
        {
            var result = _Controller.BlogSingle();
            Xunit.Assert.IsType<ViewResult>(result);
        }

        /// <summary>
        /// Test for public IActionResult Blog() => View();
        /// </summary>
        [TestMethod]
        public void Blog_Returns_View()
        {
            var result = _Controller.Blog();
            Xunit.Assert.IsType<ViewResult>(result);
        }
    }
}
