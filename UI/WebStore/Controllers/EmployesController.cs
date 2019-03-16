using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebStore.Domain.ViewModels;
using WebStore.Interfaces.Services;

namespace WebStore.Controllers
{
    //[Route("Users")]
    //[TestActionFilter]
    //[ServiceFilter(typeof(TestResultFilter))]
    [Authorize]
    public class EmployesController : Controller
    {
        private readonly IEmployeesData _EmployeesData;

        public EmployesController(IEmployeesData EmployeesData)
        {
            _EmployeesData = EmployeesData;
        }

        //[Route("Get")]
        //[TestActionFilter]
        public IActionResult Index() => View(_EmployeesData.GetAll());

        public IActionResult Details(int? id)
        {
            if (id is null)
                return BadRequest();

            var employee = _EmployeesData.GetById((int)id);
            if (employee is null)
                return NotFound();

            return View(employee);
        }

        [HttpGet, Authorize(Roles = Domain.Entities.User.AdminRole)]
        public IActionResult Edit(int? id)
        {
            if (id is null)
                return View(new EmployeeViewModel
                {
                    FirstName = "Имя",
                    SecondName = "Фамилия",
                    Age = 18
                });

            var employee = _EmployeesData.GetById((int)id);
            if (employee is null)
                return NotFound();

            return View(employee);
        }

        [HttpPost, ValidateAntiForgeryToken, Authorize(Roles = Domain.Entities.User.AdminRole)]
        public IActionResult Edit(EmployeeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                if (model.Age < 18)
                    ModelState.AddModelError("Ошибка возраста", "Не достигнуто совершеннолетие!");
                return View(model);
            }
            if (!_EmployeesData.GetAll().Any())
            {
                _EmployeesData.AddNew(model);
            }
            else
            {
                var employee = _EmployeesData.GetById(model.Id);
                if (employee is null)
                    return NotFound();

                employee.FirstName = model.FirstName;
                employee.SecondName = model.SecondName;
                employee.Patronymic = model.Patronymic;
                employee.Age = model.Age;

                _EmployeesData.UpdateEmployee(employee.Id, employee);
                _EmployeesData.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [Authorize(Roles = Domain.Entities.User.AdminRole)]
        public IActionResult Delete(int? id)
        {
            if (id is null)
                return BadRequest();

            if (_EmployeesData.GetById((int)id) is null)
                return NotFound();

            _EmployeesData.Delete((int)id);

            return RedirectToAction("Index");
        }
    }
}