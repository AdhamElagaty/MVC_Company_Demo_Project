using MVC_Company_Demo_Project.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Company_Demo_Project.Service.Interfaces
{
    public interface IEmployeeService
    {
        Employee GetById(int? id);

        IEnumerable<Employee> GetAll();

        void Add(Employee department);

        void Update(Employee department);

        void Delete(Employee department);

    }
}
