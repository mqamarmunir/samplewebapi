using Sample.Domain.Models;
using Sample.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Services
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public async Task SaveAsync(Employee employee)
        {
            var existing = await this.employeeRepository.GetByIdAsync(employee.Id);
            if (existing != null)
            {
                existing.Age = employee.Age;
                existing.FirstName = employee.FirstName;
                existing.Gender = employee.Gender;
                existing.LastName = employee.LastName;

                await this.employeeRepository.UpdateAsync(existing);
            }
            else
            {
                await this.employeeRepository.AddAsync(employee);
            }
        }

        public IReadOnlyList<Employee> GetAll(string firstName = "", string lastName = "", string gender = "")
        {
            var allEmployees = this.employeeRepository.GetQueryable();
            if (!string.IsNullOrEmpty(firstName))
            {
                allEmployees = allEmployees.Where(x => x.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase));
            }
            if (!string.IsNullOrEmpty(lastName))
            {
                allEmployees = allEmployees.Where(x => x.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase));
            }
            if (!string.IsNullOrEmpty(gender))
            {
                allEmployees = allEmployees.Where(x => x.Gender.Equals(gender, StringComparison.OrdinalIgnoreCase));
            }

            return allEmployees.ToList();
        }
    }
}
