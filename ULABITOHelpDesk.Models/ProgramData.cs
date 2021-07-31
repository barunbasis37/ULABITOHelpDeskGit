using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ULABITOHelpDesk.Models
{
    public class ProgramData :Entity
    {
        [Required(ErrorMessage = "Program Id Required"), Key, Column(Order = 1), Index("IX_ProgramId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Display(Name = "Program Id")]
        public int Id { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Type cannot be longer than 30 characters.", MinimumLength = 1)]
        [DisplayName("Program Code")]
        public string ProgramCode { get; set; }
        [Required]
        [StringLength(250)]
        [DisplayName("Program Name")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Department Code")]
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
        //[Required]
        //[DisplayName("Total Credit Hr.")]
        //public double TotalCreditHr { get; set; }
        //[Required]
        //[StringLength(10)]
        //[DisplayName("Program Status")]
        //public string ProgramStatus { get; set; }
        [Required]
        [DisplayName("Priority")]
        public int Priority { get; set; }
        [DisplayName("Is Active")]
        public bool IsActive { get; set; }
    }
}
