using MVC_Company_Demo_Project.Data.Models;
using MVC_Company_Demo_Project.Repository.Interfaces;
using MVC_Company_Demo_Project.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Company_Demo_Project.Service.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public void Add(Department entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Department entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Department> GetAll()
        {
            var departments = _departmentRepository.GetAll();
            return departments;
        }

        public Department GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Department entity)
        {
            throw new NotImplementedException();
        }
    }
}
