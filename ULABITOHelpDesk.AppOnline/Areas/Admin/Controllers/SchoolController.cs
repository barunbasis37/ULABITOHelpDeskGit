using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ULABITOHelpDesk.DataAccess.Repository.IRepository;
using ULABITOHelpDesk.Models;
using Microsoft.AspNetCore.Identity;

namespace ULABITOHelpDesk.AppOnline.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Route("admin/school")]
    public class SchoolController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public SchoolController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
       
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upsert(int? id)
        {
            School school = new School();
            if (id == null)
            {
                //this is for create
                return View(school);
            }
            //this is for edit
            school = _unitOfWork.School.Get(id.GetValueOrDefault());
            if (school == null)
            {
                return NotFound();
            }
            return View(school);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(School school)
        {
            
            if (ModelState.IsValid)
            {
                if (school.Id == 0)
                {
                    school.QueryId = Guid.NewGuid();
                    school.IsActive = true;
                    school.CreatedDate = DateTime.Now;
                    school.CreatedBy = "423036";
                    school.CreatedIp = "172.16.25.30";
                    school.UpdatedDate = DateTime.Now;
                    school.UpdatedBy = "423036";
                    school.UpdatedIp = "172.16.25.30";
                    school.IsDeleted = false;
                    _unitOfWork.School.Add(school);

                }
                else
                {
                    school.UpdatedDate = DateTime.Now;
                    //school.UpdatedBy = User.Identity.Name;
                    //school.UpdatedIp = Request.HttpContext.Connection.LocalIpAddress.ToString();
                    school.UpdatedBy = "423036";
                    school.UpdatedIp = "172.16.25.30";
                    school.IsDeleted = false;
                    _unitOfWork.School.Update(school);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(school);
        }

        #region API Calls

        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.School.GetAll().ToList();
            return Json(new {data = allObj});
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.School.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _unitOfWork.School.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });

        }

        #endregion
    }
}
