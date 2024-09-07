using AutoMapper;
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
        private readonly IMapper _mapper;

        public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public EmployeeDto GetById(int? id)
        {
            if (id is null)
                return null;

            var employee = _unitOfWork.EmployeeRepository.GetById(id.Value);
            if (employee is null)
                return null;

            EmployeeDto employeeDto = _mapper.Map<EmployeeDto>(employee);
            return employeeDto;
        }

        public IEnumerable<EmployeeDto> GetAll()
        {
            var employees = _unitOfWork.EmployeeRepository.GetAll();
            IEnumerable<EmployeeDto> mappedEmployees = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            return mappedEmployees;
        }

        public IEnumerable<EmployeeDto> GetEmployeeByName(string name)
        {
            var employees = _unitOfWork.EmployeeRepository.GetEmployeeByName(name);
            IEnumerable<EmployeeDto> mappedEmployees = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            return mappedEmployees;
        }

        public void Add(EmployeeDto employeeDto)
        {
            //manual mapping
            //var mappedEmployee = new Employee()
            //{
            //    Name = employeeDto.Name,
            //    Age = employeeDto.Age,
            //    HiringDate = employeeDto.HiringDate,
            //    Email = employeeDto.Email,
            //    PhoneNumber = employeeDto.PhoneNumber,
            //    ImageUrl = employeeDto.ImageUrl,
            //    Address = employeeDto.Address,
            //    Salary = employeeDto.Salary,
            //    DepartmentId = employeeDto.DepartmentId,
            //    IsDeleted = false,
            //};

            Employee employee = _mapper.Map<Employee>(employeeDto);
            _unitOfWork.EmployeeRepository.Add(employee);
            _unitOfWork.Complete();
        }

        public void Update(EmployeeDto employee)
        {
            //_unitOfWork.EmployeeRepository.Update(employee);
            _unitOfWork.Complete();
        }

        public void Delete(EmployeeDto employeeDto)
        {
            Employee mappedEmployee = _mapper.Map<Employee>(employeeDto);
            _unitOfWork.EmployeeRepository.Delete(mappedEmployee);
            _unitOfWork.Complete();
        }
    }
}
