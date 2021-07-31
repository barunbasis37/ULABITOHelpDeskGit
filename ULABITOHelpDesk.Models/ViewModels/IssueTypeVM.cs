using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace ULABITOHelpDesk.Models.ViewModels
{
    public class IssueTypeVM
    {
        public IssueType IssueType { get; set; }
        public IEnumerable<SelectListItem> UserTypeList { get; set; }
    }
}
