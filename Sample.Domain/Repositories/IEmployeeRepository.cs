using System;
using System.Collections.Generic;
using System.Text;
using Sample.Domain.Models;

namespace Sample.Domain.Repositories
{
    public interface IEmployeeRepository : IGenericRepositoryAsync<Employee>
    {

    }
}
