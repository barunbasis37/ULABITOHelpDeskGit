using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ULABITOHelpDesk.Models
{
    public class IssueSubtype : Entity
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Sub-type Name")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [Display]
        public bool IsActive { get; set; }
        public int Priority { get; set; }

        public int IssueTypeId { get; set; }
        [ForeignKey("IssueTypeId")]
        public IssueType IssueType { get; set; }
    }
}
