using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ULABITOHelpDesk.DataAccess.Data;
using ULABITOHelpDesk.DataAccess.Repository.IRepository;
using ULABITOHelpDesk.Models;

namespace ULABITOHelpDesk.DataAccess.Repository
{
    public class IssueSubtypeRepository : Repository<IssueSubtype>, IIssueSubtypeRepository
    {
        private readonly ApplicationDbContext _db;
        public IssueSubtypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(IssueSubtype issueSubtype)
        {
            //var objFromDb = _db.IssueTypes.FirstOrDefault(s => s.Id == issueType.Id);
            //if (objFromDb != null)
            //{
            //    objFromDb.Name = issueType.Name;
            //    _db.SaveChanges();
            //}
            _db.Update(issueSubtype);
        }
    }
}
