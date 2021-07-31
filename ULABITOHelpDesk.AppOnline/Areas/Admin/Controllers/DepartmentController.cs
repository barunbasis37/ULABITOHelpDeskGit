using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using ULABITOHelpDesk.DataAccess.Repository.IRepository;
using ULABITOHelpDesk.Models;
using ULABITOHelpDesk.Models.ViewModels;
using ULABITOHelpDesk.Utility;

namespace ULABITOHelpDesk.AppOnline.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_SuperAdmin)]
    public class DepartmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upsert(int? id)
        {
            DepartmentVM departmentVM = new DepartmentVM()
            {
                Department = new Department(),
                SchoolList = _unitOfWork.School.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
            };
            if (id == null)
            {
                //this is for create
                return View(departmentVM);
            }
            //this is for edit
            departmentVM.Department = _unitOfWork.Department.Get(id.GetValueOrDefault());
            if (departmentVM.Department == null)
            {
                return NotFound();
            }
            return View(departmentVM);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(DepartmentVM departmentVM)
        {

            if (ModelState.IsValid)
            {
                if (departmentVM.Department.Id == 0)
                {
                    departmentVM.Department.QueryId = Guid.NewGuid();
                    departmentVM.Department.IsActive = true;
                    departmentVM.Department.CreatedDate = DateTime.Now;
                    departmentVM.Department.CreatedBy = "423036";
                    departmentVM.Department.CreatedIp = "172.16.25.30";
                    departmentVM.Department.UpdatedDate = DateTime.Now;
                    departmentVM.Department.UpdatedBy = "423036";
                    departmentVM.Department.UpdatedIp = "172.16.25.30";
                    departmentVM.Department.IsDeleted = false;
                    _unitOfWork.Department.Add(departmentVM.Department);

                }
                else
                {
                    departmentVM.Department.UpdatedDate = DateTime.Now;
                    //department.UpdatedBy = User.Identity.Name;
                    //department.UpdatedIp = Request.HttpContext.Connection.LocalIpAddress.ToString();
                    departmentVM.Department.UpdatedBy = "423036";
                    departmentVM.Department.UpdatedIp = "172.16.25.30";
                    departmentVM.Department.IsDeleted = false;
                    _unitOfWork.Department.Update(departmentVM.Department);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }

            departmentVM.SchoolList = _unitOfWork.School.GetAll().Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
            return View(departmentVM);
        }

        #region API Calls

        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.Department.GetAll(includeProperties: "School");
            return Json(new { data = allObj });
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Department.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _unitOfWork.Department.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });

        }

        #endregion
    }
}
