using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ULABITOHelpDesk.Models;

namespace ULABITOHelpDesk.DataAccess.Repository.IRepository
{
    public interface IIssueTypeRepository : IRepository<IssueType>
    {
        void Update(IssueType issueType);
    }
}
