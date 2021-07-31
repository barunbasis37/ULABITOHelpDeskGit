using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ULABITOHelpDesk.Models
{
    public class IssueInitiate : Entity
    {
        [Required(ErrorMessage = "Id Required"), Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Display(Name = "Id")]
        public int Id { get; set; }
        //[Required(ErrorMessage = "Select Department")]
        //[Display(Name = "Department")]
        //public int DepartmentId { get; set; }
        //[ForeignKey("DepartmentId")]
        //public Department Department { get; set; }
        [Display(Name = "Program")]
        public int ProgramId { get; set; }
        [ForeignKey("ProgramId")]
        public ProgramData ProgramData { get; set; }
        //[Required]
        //public int? IssueTypeId { get; set; }
        //[ForeignKey("IssueTypeId")]
        //public IssueType IssueType { get; set; }
        [Required(ErrorMessage = "Select a Issue Subtype")]
        public int? IssueSubTypeId { get; set; }
        [ForeignKey("IssueSubTypeId")]
        public IssueSubtype IssueSubtype { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public string ImagePath { get; set; }


    }
}
