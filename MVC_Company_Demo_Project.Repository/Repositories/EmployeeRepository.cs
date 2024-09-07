using MVC_Company_Demo_Project.Data.Contexts;
using MVC_Company_Demo_Project.Data.Models;
using MVC_Company_Demo_Project.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Company_Demo_Project.Repository.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly CompanyDbContext _context;
        public EmployeeRepository(CompanyDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetEmployeeByName(string name) => _context.Employees.Where(x => x.Name.Trim().ToLower().Contains(name.Trim().ToLower()));

        public IEnumerable<Employee> GetEmployeesByAddress(string address) => _context.Employees.Where(x => x.Address == address);
    }
}
