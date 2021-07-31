using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ULABITOHelpDesk.Models
{
    public class UserType : Entity
    {
        [Required(ErrorMessage = "User Type Id Required"), Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Display(Name = "User Type Id")]
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Priority Level")]
        public int PriorityLevel { get; set; }
        [Required]
        [Display(Name = "Active")]
        public bool IsActive { get; set; }
    }
}
