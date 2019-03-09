using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebStore.Domain.ViewModels;
using WebStore.Interfaces.Services;

namespace WebStore.ServiceHosting.Controllers
{
    /// <summary>
    /// Controller for Employees
    /// Looks like proxy object
    /// </summary>
    [ApiController, Route("api/[controller]"), Produces("application/json")]
    public class EmployeesController : ControllerBase, IEmployeesData
    {
        private readonly IEmployeesData _EmployeesData;

        public EmployeesController(IEmployeesData EmployeesData) => _EmployeesData = EmployeesData;

        /// <summary>
        /// Http Get Method
        /// </summary>
        /// <returns>List of Employees</returns>
        [HttpGet, ActionName("Get")]
        public IEnumerable<EmployeeViewModel> GetAll()
        {
            return _EmployeesData.GetAll();
        }

        /// <summary>
        /// Http Get Method by id
        /// </summary>
        /// <param name="id">id of Employee</param>
        /// <returns>Employee</returns>
        [HttpGet("{id}"), ActionName("Get")]
        public EmployeeViewModel GetById(int id)
        {
            return _EmployeesData.GetById(id);
        }

        /// <summary>
        /// Http Put Method change by id
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="employee">incoming data of employee</param>
        /// <returns>updated employee</returns>
        [HttpPut("{id}"), ActionName("Put")]
        public EmployeeViewModel UpdateEmployee(int id, [FromBody] EmployeeViewModel employee)
        {
            return _EmployeesData.UpdateEmployee(id, employee);
        }

        /// <summary>
        /// Http Post Method create new Employee
        /// </summary>
        /// <param name=employee">incoming data of employee</param>
        [HttpPost, ActionName("Post")]
        public void AddNew([FromBody] EmployeeViewModel employee)
        {
            _EmployeesData.AddNew(employee);
        }

        /// <summary>
        /// Http Delete Method by id
        /// </summary>
        /// <param name="id">id</param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _EmployeesData.Delete(id);
        }

        /// <summary>
        /// No Action, just SaveChanges
        /// </summary>
        [NonAction]
        public void SaveChanges()
        {
            _EmployeesData.SaveChanges();
        }
    }
}