using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ULABITOHelpDesk.Models
{
    public class Employee : Entity
    {
        [Required(ErrorMessage = "Employee Id Required"), Key, Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None), StringLength(20, ErrorMessage = "Employee Id cannot be longer than 20 characters.", MinimumLength = 1)]
        [Index("IX_Id", IsUnique = true)]
        [Display(Name = "Employee ID")]
        public string EmployeeId { get; set; }
        [Required]
        [StringLength(150, ErrorMessage = "Name cannot be longer than 150 characters.", MinimumLength = 1)]
        [Index("IX_Name", IsUnique = true)]
        [Display(Name = "Employee Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Designation")]
        public string DesignationId { get; set; }
        [ForeignKey("DesignationId")]
        public Designation Designation1 { get; set; }
        [Display(Name = "Department Name")]
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId"), Column(Order = 1)]
        public virtual Department Department { get; set; }
        [Required]
        [Display(Name = "Member Since")]
        public DateTime MemberSinceDate { get; set; }
        [Required]
        [Display(Name = "Active")]
        public bool IsActive { get; set; }

    }
}
