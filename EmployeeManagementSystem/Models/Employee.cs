using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementSystem.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(200)]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        
        [Required]
        [MaxLength(200)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [NotMapped]
        [DisplayName("Full Name")]
        public string FullName { get { return FirstName + " " + LastName; } }

        [Required]
        [EmailAddress]
        [MaxLength(200)]
        public string Email { get; set; }
        
        [Required]
        [MaxLength(20)]
        [DisplayName("Phone No.")]
        public string PhoneNumber { get; set; }
        
        [Required]
        [MaxLength(500)]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Required]
        [MaxLength(200)]
        public string District { get; set; }

        [Required]
        [MaxLength(100)]
        public string State { get; set; }

        [Required]
        [MaxLength(100)]
        public string Country { get; set; }

        [Required]
        [Column(TypeName ="Date")]
        [DataType(DataType.Date)]
        [DisplayName("Hire Date")]
        public DateTime HireDate { get; set; }

        [DisplayName("Department")]
        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        [DisplayName("Designation")]
        public int DesignationId { get; set; }

        public Designation Designation { get; set; }

        public ICollection<Leave> Leaves { get; set; }
        public Salary Salary { get; set; }
    }
}
