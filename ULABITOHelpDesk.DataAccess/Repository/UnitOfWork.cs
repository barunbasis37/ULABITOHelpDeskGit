using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ULABITOHelpDesk.DataAccess.Data;
using ULABITOHelpDesk.DataAccess.Repository.IRepository;

namespace ULABITOHelpDesk.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            School = new SchoolRepository(_db);
            Department = new DepartmentRepository(_db);
            Program = new ProgramRepository(_db);
            UserType = new UserTypeRepository(_db);
            IssueType = new IssueTypeRepository(_db);
            IssueSubtype = new IssueSubtypeRepository(_db);
            IssueInitiate = new IssueInitiateRepository(_db);
            SP_Call = new SP_Call(_db);
        }

        public ISchoolRepository School { get; private set; }
        public IDepartmentRepository Department { get; private set; }
        public IProgramRepository Program { get; private set; }
        public IIssueTypeRepository IssueType { get; set; }
        public IIssueSubtypeRepository IssueSubtype { get; set; }
        public IUserTypeRepository UserType { get; set; }
        public IIssueInitiateRepository IssueInitiate { get; set; }
        public ISP_Call SP_Call { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
