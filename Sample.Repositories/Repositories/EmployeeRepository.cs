
using Microsoft.EntityFrameworkCore;
using Sample.Domain.Models;
using Sample.Domain.Repositories;
using Sample.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Test.Infrastructure.Persistence.Repository
{
    public class EmployeeRepositoryAsync : GenericRepositoryAsync<Employee>, IEmployeeRepository
    {
        private readonly DbSet<Employee> _emplyees;

        public EmployeeRepositoryAsync(EmployeeDbContext dbContext) : base(dbContext)
        {
            _emplyees = dbContext.Set<Employee>();
        }
    }
}
