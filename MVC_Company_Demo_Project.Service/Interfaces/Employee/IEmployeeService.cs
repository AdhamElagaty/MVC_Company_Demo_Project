using MVC_Company_Demo_Project.Data.Models;
using MVC_Company_Demo_Project.Service.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Company_Demo_Project.Service.Interfaces
{
    public interface IEmployeeService
    {
        EmployeeDto GetById(int? id);

        IEnumerable<EmployeeDto> GetAll();

        public IEnumerable<EmployeeDto> GetEmployeeByName(string name);

        void Add(EmployeeDto employeeDtio);

        void Update(EmployeeDto employeeDtio);

        void Delete(EmployeeDto employeeDtio);

    }
}
