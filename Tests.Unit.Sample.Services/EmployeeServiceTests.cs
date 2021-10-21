using Moq;
using NUnit.Framework;
using Sample.Domain.Models;
using Sample.Domain.Repositories;
using Sample.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tests.Unit.Sample.Services
{
    public class EmployeeServiceTests
    {
        private Mock<IEmployeeRepository> employeeRepository = default!;
        public EmployeeService employeeService = default!;

        [SetUp]
        public void Setup()
        {
            this.employeeRepository = new Mock<IEmployeeRepository>();

            this.employeeRepository.Setup(x => x.AddAsync(It.IsAny<Employee>())).ReturnsAsync(new Employee
            {
                Id = System.Guid.Parse("ad67d926-c066-4baa-ac83-54887d255880"),
                Age = 18.5M,
                FirstName = "Qamar",
                LastName = "Munir",
                Gender = "Male",
            });
            this.employeeRepository.Setup(x => x.GetByIdAsync(System.Guid.Parse("ad67d926-c066-4baa-ac83-54887d255880"))).ReturnsAsync(new Employee
            {
                Id = System.Guid.Parse("ad67d926-c066-4baa-ac83-54887d255880"),
                Age = 18.5M,
                FirstName = "Qamar",
                LastName = "Munir",
                Gender = "Male",
            });
            this.employeeRepository.Setup(x => x.GetQueryable()).Returns(new List<Employee>() {
            new Employee
            {
                Id = System.Guid.Parse("ad67d926-c066-4baa-ac83-54887d255880"),
                Age = 18.5M,
                FirstName = "Qamar",
                LastName = "Munir",
                Gender = "Male",
            },
            new Employee
            {
                Id = System.Guid.Parse("481f11bb-9d05-4a31-94a4-fc741c15f6e1"),
                Age = 22.5M,
                FirstName = "Falek",
                LastName = "Sher",
                Gender = "Male",
            },
            }.AsQueryable()) ;

            this.employeeRepository.Setup(x => x.GetByIdAsync(System.Guid.Parse("66c8547b-ee5c-4182-87ab-cd2ac608653f"))).Returns<Employee>(null);
            this.employeeService = new EmployeeService(this.employeeRepository.Object);
        }

        [Test]
        public async Task TestSave()
        {
            var employeeObject = new Employee
            {
                Id = System.Guid.Parse("ad67d926-c066-4baa-ac83-54887d255880"),
                Age = 18.5M,
                FirstName = "Qa",
                LastName = "Munir",
                Gender = "Male",
            };

            await this.employeeService.SaveAsync(employeeObject);

            Assert.That(employeeObject.FirstName, Is.EqualTo("Qa"));
            Assert.That(employeeObject.LastName, Is.EqualTo("Munir"));
        }

        [Test]
        public void TestGet()
        {
            var employees = this.employeeService.GetAll("Falek");

            Assert.That(employees.Count, Is.EqualTo(1));
            Assert.That(employees[0].LastName, Is.EqualTo("Sher"));
            
            employees = this.employeeService.GetAll(lastName: "Munir");

            Assert.That(employees.Count, Is.EqualTo(1));
            Assert.That(employees[0].FirstName, Is.EqualTo("Qamar"));

            employees = this.employeeService.GetAll(gender: "Male");

            Assert.That(employees.Count, Is.EqualTo(2));
        }
    }
}