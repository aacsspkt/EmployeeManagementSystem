using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementSystem.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(200)]
        public string Email { get; set; }

        [Required]
        [DisplayName("Role")]
        public Role Role { get; set; }

        [Required]
        [MaxLength(100)]
        public string Password { get; set; }

        [Required]
        [NotMapped]
        [Compare("Password")]
        [MaxLength(100)]
        public string ConfirmPassword { get; set; }
    }

    public enum Role
    {
        Admin,
        Employee
    }
}
