using System;
using System.ComponentModel.DataAnnotations;

namespace Sample.Domain.Models
{
    /// <summary>
    /// The employee class.
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Employee()
        { }

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="age">The age.</param>
        /// <param name="gender">The gender.</param>
        public Employee(string firstName, string lastName, decimal age, string gender)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Gender = gender;
        }

        [Required]
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public decimal Age { get; set; }
        [Required]
        public string Gender { get; set; }
        public string FullName { 
            get 
            {
                return string.Concat(this.FirstName, " ", this.LastName);
            }
        }
    }
}
