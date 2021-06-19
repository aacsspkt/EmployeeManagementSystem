using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementSystem.Models
{
    public class Vacancy
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [DisplayName("Designation")]
        public int DesignationId { get; set; }

        [DisplayName("Designation")]
        public Designation Designation { get; set; }
        
        [Required]
        [DisplayName("No. of Quota")]
        public int NumberOfQuota { get; set; }

        [Required]
        [Column(TypeName ="Date")]
        [DataType(DataType.Date)]
        [DisplayName("Announce Date")]
        public DateTime AnnounceDate { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        [DataType(DataType.Date)]
        [DisplayName("Expiry Date")]
        public DateTime ExpiryDate { get; set; }
    }
}
