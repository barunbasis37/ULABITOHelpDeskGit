using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ULABITOHelpDesk.Models
{
    public class Designation : Entity
    {
        
        [Required(ErrorMessage = "Designation Id Required"), Key, Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None), StringLength(20, ErrorMessage = "Designation Id cannot be longer than 20 characters.", MinimumLength = 1)]
        [Index("IX_Id", IsUnique = true)]
        [Display(Name = "Designation ID")]
        public string DesignationId { get; set; }
        [Required]
        [StringLength(150, ErrorMessage = "Name cannot be longer than 150 characters.", MinimumLength = 1)]
        [Index("IX_Name", IsUnique = true)]
        [Display(Name = "Designation Name")]
        public string Name { get; set; }
        [Display(Name = "Designation Type")]
        public string DesignationType { get; set; }
        [Required]
        [Display(Name = "Active")]
        public bool IsActive { get; set; }

    }
}
