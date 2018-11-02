using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRUDModal.Common.Repository;
using CRUDModal.DataAccess.Context;
using CRUDModal.DataAccess.Models;
using CRUDModal.DataAccess.Params;

namespace CRUDModal.Controllers
{
    public class EmployeesController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeesController(IEmployeeRepository employeeRepositoy)
        {
            _employeeRepository = employeeRepositoy;
        }


        // GET: Employees
        public ActionResult Index()
        {
            var employee = _employeeRepository.Get();
            return View(employee);
        }


        //get Departments to dropdownlist
        public JsonResult DepList()
        {
            
            db.Configuration.ProxyCreationEnabled = false;
            List<Department> Deplist = db.Departments.Where(x => x.IsDelete==false).OrderBy(x => x.Name).ToList();
            return Json(Deplist, JsonRequestBehavior.AllowGet);
        
        
        }

        //get Roles to dropdownlist
        public JsonResult RoleList()
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<Role> role = db.Roles.OrderBy(x => x.Name).ToList();
            return Json(role, JsonRequestBehavior.AllowGet);
        }

        //create employee
        public ActionResult Create()
        {
            List<Department> DepList = db.Departments.ToList();
            ViewBag.DepList = new SelectList(DepList, "Id", "Name");
            List<Role> RoleList = db.Roles.ToList();
            ViewBag.RoleList = new SelectList(RoleList, "Id", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeParam param, HttpPostedFileBase ImageUpload)
        {
            if (ModelState.IsValid)
            {
                if (ImageUpload != null)
                {
                    if (ImageUpload.ContentType == "image/jpg" || ImageUpload.ContentType == "image/png" || ImageUpload.ContentType == "image/bmp" || ImageUpload.ContentType == "image/gif" || ImageUpload.ContentType == "image/jpeg")
                    {
                        string fileName = Path.GetFileNameWithoutExtension(ImageUpload.FileName);
                        //string extension = Path.GetExtension(ImageUpload.FileName);
                        fileName = fileName + DateTime.Now.ToString("yymmssfff");

                        ImageUpload.SaveAs(Server.MapPath("/") + "/Images/" + fileName + ImageUpload.FileName );
                        param.Foto = fileName + ImageUpload.FileName;
                    }
                    else
                        return View();
                }
                else
                    return View();

                int noSeq = db.Employees.Count() + 14001;
                param.EmployeeNo = noSeq;
                _employeeRepository.Insert(param);
                //return RedirectToAction("Index");
            }
            return Json(param, JsonRequestBehavior.AllowGet);
        }
        

        //delete employee
        public JsonResult Delete(int id)
        {
            _employeeRepository.Delete(id);
            return Json(JsonRequestBehavior.AllowGet);
        }

        //get id employee
        public JsonResult GetByID(int id)
        {
            EmployeeParam param = new EmployeeParam();
            var employee = _employeeRepository.Get(id);
            //var departments = db.Departments.Where(i => i.IsDelete == false).OrderBy(x => x.Name).Select(i => new SelectListItem()
            //{
            //    Text = i.Name,
            //    Value = i.Id.ToString(),
            //    Selected = false
            //}).ToArray();
            //foreach (var get in departments)
            //{
            //    if (get.Value.Equals(employee.Departments.Id.ToString()))
            //    {
            //        get.Selected = true;
            //        break;
            //    }
            //}
            //param.Departments = departments.ToString();
            return Json(employee, JsonRequestBehavior.AllowGet);
        }
    }
}