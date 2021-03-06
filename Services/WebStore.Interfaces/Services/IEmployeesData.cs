﻿using System.Collections.Generic;
using WebStore.Domain.ViewModels;

namespace WebStore.Interfaces.Services
{
    /// <summary>
    /// Employees Data Interface
    /// </summary>
    public interface IEmployeesData
    {
        IEnumerable<EmployeeViewModel> GetAll();

        EmployeeViewModel GetById(int id);

        EmployeeViewModel UpdateEmployee(int id, EmployeeViewModel employee);

        void AddNew(EmployeeViewModel NewEmployee);

        void Delete(int id);
        
        void SaveChanges();
    }
}
