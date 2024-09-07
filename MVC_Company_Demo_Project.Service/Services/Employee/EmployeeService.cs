using MVC_Company_Demo_Project.Data.Models;
using MVC_Company_Demo_Project.Repository.Interfaces;
using MVC_Company_Demo_Project.Service.Interfaces;
using MVC_Company_Demo_Project.Service.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Company_Demo_Project.Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public EmployeeDto GetById(int? id)
        {
            if (id is null)
                return null;

            var employee = _unitOfWork.EmployeeRepository.GetById(id.Value);
            if (employee is null)
                return null;

            var mappedEmployees = new EmployeeDto
            {
                Id = employee.Id,
                Name = employee.Name,
                Address = employee.Address,
                Age = employee.Age,
                CreateAt = employee.CreateAt,
                DepartmentId = employee.DepartmentId,
                Email = employee.Email,
                HiringDate = employee.HiringDate,
                ImageUrl = employee.ImageUrl,
                IsDeleted = employee.IsDeleted,
                PhoneNumber = employee.PhoneNumber,
                Salary = employee.Salary
            };
            return mappedEmployees;
        }

        public IEnumerable<EmployeeDto> GetAll()
        {
            var employees = _unitOfWork.EmployeeRepository.GetAll();
            var mappedEmployees = employees.Select(x => new EmployeeDto
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
                Age = x.Age,
                CreateAt = x.CreateAt,
                DepartmentId = x.DepartmentId,
                Email = x.Email,
                HiringDate = x.HiringDate,
                ImageUrl = x.ImageUrl,
                IsDeleted = x.IsDeleted,
                PhoneNumber = x.PhoneNumber,
                Salary = x.Salary
            });
            return mappedEmployees;
        }

        public IEnumerable<EmployeeDto> GetEmployeeByName(string name)
        {
            var employees = _unitOfWork.EmployeeRepository.GetEmployeeByName(name);
            var mappedEmployees = employees.Select(x => new EmployeeDto
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
                Age = x.Age,
                CreateAt = x.CreateAt,
                DepartmentId = x.DepartmentId,
                Email = x.Email,
                HiringDate = x.HiringDate,
                ImageUrl = x.ImageUrl,
                IsDeleted = x.IsDeleted,
                PhoneNumber = x.PhoneNumber,
                Salary = x.Salary
            });
            return mappedEmployees;
        }

        public void Add(EmployeeDto employeeDto)
        {
            //manual mapping
            var mappedEmployee = new Employee()
            {
                Name = employeeDto.Name,
                Age = employeeDto.Age,
                HiringDate = employeeDto.HiringDate,
                Email = employeeDto.Email,
                PhoneNumber = employeeDto.PhoneNumber,
                ImageUrl = employeeDto.ImageUrl,
                Address = employeeDto.Address,
                Salary = employeeDto.Salary,
                DepartmentId = employeeDto.DepartmentId,
                IsDeleted = false,
            };

            _unitOfWork.EmployeeRepository.Add(mappedEmployee);
            _unitOfWork.Complete();
        }

        public void Update(EmployeeDto employee)
        {
            //_unitOfWork.EmployeeRepository.Update(employee);
            _unitOfWork.Complete();
        }

        public void Delete(EmployeeDto employeeDto)
        {
            var mappedEmployee = new Employee()
            {
                Name = employeeDto.Name,
                Age = employeeDto.Age,
                HiringDate = employeeDto.HiringDate,
                Email = employeeDto.Email,
                PhoneNumber = employeeDto.PhoneNumber,
                ImageUrl = employeeDto.ImageUrl,
                Address = employeeDto.Address,
                Salary = employeeDto.Salary,
                DepartmentId = employeeDto.DepartmentId,
                IsDeleted = false,
            };
            _unitOfWork.EmployeeRepository.Delete(mappedEmployee);
            _unitOfWork.Complete();
        }
    }
}
