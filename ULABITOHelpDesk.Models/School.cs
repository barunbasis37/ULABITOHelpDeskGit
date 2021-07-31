using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ULABITOHelpDesk.Models
{
    public class School :Entity
    {
        [Required(ErrorMessage = "School Id Required"), Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Display(Name = "School Id")]
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "School Name cannot be longer than 50 characters.", MinimumLength = 1)]
        [Index("IX_Name", IsUnique = true)]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "School Name cannot be longer than 50 characters.", MinimumLength = 1)]
        [Index("IX_Code", IsUnique = true)]
        [Display(Name = "School Code")]
        public string SchoolCode { get; set; }
        [Required]
        [Display(Name = "Priority Level")]
        public int PriorityLevel { get; set; }
        [Required]
        [Display(Name = "Active")]
        public bool IsActive { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
    }
}
