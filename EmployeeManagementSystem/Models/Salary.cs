using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementSystem.Models
{
    public class Salary
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [DisplayName("Employee Email")]
        public int EmployeeId { get; set; }

        [DisplayName("Employee Email")]
        public Employee Employee { get; set; }

        [Required]
        [DisplayName("Designation")]
        public int DesignationId { get; set; }

        [DisplayName("Designation")]
        public Designation Designation { get; set; }

        [Required]
        [DisplayName("Salary Level")]
        public Level SalaryLevel { get; set; }

        public enum Level
        {
            Initial,
            One,
            Two,
            Three,
            Four,
            FIve,
            Six,
            Seven,
            Eight,
            Nine,
            Ten
        }

        [Required]    
        [Column(TypeName ="decimal(9,2)")]
        [DisplayName("Total Salary Amount")]
        public decimal TotalSalaryAmount { get; set; }
    }
}
