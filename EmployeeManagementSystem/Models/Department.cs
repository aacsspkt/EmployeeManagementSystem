using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Models
{
    public class Department
    {
        [Key]
        public int Id { get; private set; }
        
        [Required]
        [MaxLength(200)]
        public string DepartmentName { get; private set; }
        
        public Employee Manager { get; private set; } 

    }
}
