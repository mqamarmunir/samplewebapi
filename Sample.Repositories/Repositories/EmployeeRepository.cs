
using Microsoft.EntityFrameworkCore;
using Sample.Domain.Models;
using Sample.Domain.Repositories;
using Sample.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Repositories
{
    public class EmployeeRepositoryAsync : GenericRepositoryAsync<Employee>, IEmployeeRepository
    {
        private readonly DbSet<Employee> _employees;

        public EmployeeRepositoryAsync(EmployeeDbContext dbContext) : base(dbContext)
        {
            _employees = dbContext.Set<Employee>();
        }
    }
}
