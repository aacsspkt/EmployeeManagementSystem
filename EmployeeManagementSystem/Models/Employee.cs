using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; private set; }
        
        [Required]
        [MaxLength(300)]
        [MinLength(2)]
        public string FirstName { get; private set; }
        
        [Required]
        [MaxLength(300)]
        [MinLength(3)]
        public string SurName { get; private set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; private set; }
        
        [Required]
        [MaxLength(20)]
        public string PhoneNumber { get; private set; }
        
        [Required]
        public Address EmployeeAddress { get; private set; }
        
        [Required]
        public DateTime HireDate { get; private set; }
        
        [Required]
        public Department Department { get; private set; }
        public Designation Designation { get; private set; }
    }
}
