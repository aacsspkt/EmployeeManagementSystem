using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementSystem.Models
{
    public class Leave
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [DisplayName("Employee Email")]
        public int EmployeeId { get; set; }

        [DisplayName("Employee Email")]
        public Employee Employee { get; set; }
        
        [Required]
        [Column(TypeName ="Date")]
        [DataType(DataType.Date)]
        [DisplayName("Leave Start Date")]
        public DateTime LeaveStartDate { get; set; }
        
        [Required]
        [DisplayName("No. Of Days")]
        public int NumberOfDays { get; set; }
        
        [MaxLength(500)]
        [DisplayName("Leave Reason")]
        public string LeaveReason { get; set; }
    }
}
