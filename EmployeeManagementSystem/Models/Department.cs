using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementSystem.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(200)]
        [DisplayName("Department Name")]
        public string DepartmentName { get; set; }

        public ICollection<Designation> Designations { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
