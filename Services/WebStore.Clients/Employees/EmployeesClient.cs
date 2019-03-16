using System.Collections.Generic;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using WebStore.Clients.Base;
using WebStore.Domain.ViewModels;
using WebStore.Interfaces.Services;

namespace WebStore.Clients.Employees
{
    public class EmployeesClient : BaseClient, IEmployeesData
    {
        private readonly ILogger<EmployeesClient> _Logger;

        public EmployeesClient(IConfiguration configuration, ILogger<EmployeesClient> Logger) : base(configuration)
        {
            _Logger = Logger;
            ServiceAddress = "api/employees";
        }

        public IEnumerable<EmployeeViewModel> GetAll()
        {
            return Get<List<EmployeeViewModel>>(ServiceAddress);
        }

        public EmployeeViewModel GetById(int id)
        {
            return Get<EmployeeViewModel>($"{ServiceAddress}/{id}");
        }

        public EmployeeViewModel UpdateEmployee(int id, EmployeeViewModel employee)
        {
            _Logger.LogInformation($"Update Employee with id {id} with new information: {employee.FirstName} {employee.SecondName} {employee.Age} and etc.");
            var response = Put($"{ServiceAddress}/{id}", employee);
            return response.Content.ReadAsAsync<EmployeeViewModel>().Result;
        }

        public void AddNew(EmployeeViewModel NewEmployee)
        {
            _Logger.LogInformation($"Add new Employee with new information: {NewEmployee.FirstName} {NewEmployee.SecondName} {NewEmployee.Age} and etc.");
            Post(ServiceAddress, NewEmployee);
        }

        public void Delete(int id)
        {
            _Logger.LogInformation($"Delete existing Employee with id {id}");
            Delete($"{ServiceAddress}/{id}");
        }

        public void SaveChanges()
        {

        }
    }
}
