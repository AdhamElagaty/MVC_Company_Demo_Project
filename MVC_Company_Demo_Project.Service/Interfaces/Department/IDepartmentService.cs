using MVC_Company_Demo_Project.Data.Models;
using MVC_Company_Demo_Project.Service.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Company_Demo_Project.Service.Interfaces
{
    public interface IDepartmentService
    {
        DepartmentDto GetById(int? id);

        IEnumerable<DepartmentDto> GetAll();

        void Add(DepartmentDto departmentDto);

        void Update(DepartmentDto departmentDto);

        void Delete(DepartmentDto departmentDto);
    }
}
