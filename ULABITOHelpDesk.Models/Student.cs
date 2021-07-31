using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ULABITOHelpDesk.Models
{
    public class Student :Entity
    {

        [Required, Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Index("IX_Id", IsUnique = true)]
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Required,Column(Order = 2)]
        [Index("IX_StdId", IsUnique = true)]
        [Display(Name = "Student ID")]
        public int StudentId { get; set; }
        [Required]
        [StringLength(150, ErrorMessage = "Name cannot be longer than 150 characters.", MinimumLength = 1)]
        [Index("IX_Name", IsUnique = true)]
        [Display(Name = "Student Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Contact No")]
        public int ContactNo { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name = "Program Name")]
        public int ProgramId { get; set; }
        [ForeignKey("ProgramId"), Column(Order = 1)]
        public virtual ProgramData Program { get; set; }
        [Display(Name = "Active")]
        public bool IsActive { get; set; }
        [Display(Name = "Graduate")]
        public bool IsGraduate { get; set; }
        

    }
}
