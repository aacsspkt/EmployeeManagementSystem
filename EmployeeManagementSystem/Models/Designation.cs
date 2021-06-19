using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementSystem.Models
{
    public partial class Designation
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(200)]
        [DisplayName("Designation")]
        public string DesignationName { get; set; }
        
        [Required]
        [DisplayName("Department")]
        public int DepartmentId { get; set; }

        public Department Department { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(9,2)")]
        [DisplayName("Initial Salary")]
        public decimal InitialSalary { get; set; }

        public ICollection<Employee> Employees { get; set; }
        public ICollection<Vacancy> Vacancies { get; set; }
        public ICollection<Salary> Salaries { get; set; }


    }
}
