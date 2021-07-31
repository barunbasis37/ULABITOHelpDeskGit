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
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        private readonly ApplicationDbContext _db;
        public DepartmentRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;
        }

        public void Update(Department department)
        {
            _db.Update(department);

        }
    }
}
