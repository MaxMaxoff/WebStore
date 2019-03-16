using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebStore.Controllers;
using WebStore.Interfaces.Services;

namespace WebStore.Tests
{
    [TestClass]
    public class EmployesControllerTests
    {
        private EmployesController _Controller;

        [TestInitialize]
        public void Initialize()
        {
            var employesData_mock = new Mock<IEmployeesData>();

            _Controller = new EmployesController(employesData_mock.Object);
        }

        /// <summary>
        /// Test for public IActionResult Index() => View();
        /// </summary>
        [TestMethod]
        public void Index_Returns_View()
        {
            var result = _Controller.Index();
            Xunit.Assert.IsType<ViewResult>(result);
        }


    }
}
