using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ULABITOHelpDesk.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ISchoolRepository School { get; }
        IDepartmentRepository Department { get; }
        IProgramRepository Program { get; }
        IUserTypeRepository UserType { get; }
        IIssueTypeRepository IssueType { get; }
        IIssueSubtypeRepository IssueSubtype { get; }
        IIssueInitiateRepository IssueInitiate { get; }
        ISP_Call SP_Call { get; }

        void Save();
    }
}
