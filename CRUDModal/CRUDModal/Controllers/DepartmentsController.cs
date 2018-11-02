using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUDModal.Common.Repository;
using CRUDModal.DataAccess.Context;
using CRUDModal.DataAccess.Models;
using CRUDModal.DataAccess.Params;

namespace CRUDModal.Controllers
{
    public class DepartmentsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentsController(IDepartmentRepository departmentR)
        {
            _departmentRepository = departmentR;
        }
        // GET: Departments
        public ActionResult Index()
        {
            var department = _departmentRepository.Get();
            
            return View(department);
        }
        public ActionResult Create()
        {            
            return View();
        }
        [HttpPost]
        public ActionResult Create(DepartmentParam param)
        {
            _departmentRepository.Insert(param);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            var department = _departmentRepository.Get(id);
            var toview = new DepartmentParam(department);
            return View(toview);
        }
        [HttpPost]
        public ActionResult Edit(int? id, DepartmentParam param)
        {
            if (ModelState.IsValid)
            {
                _departmentRepository.Update(id, param);
                return RedirectToAction("Index");
            }
            return View(param);
        }


        public JsonResult Add(DepartmentParam param)
        {
            _departmentRepository.Insert(param);
            return Json(Index(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetByID(int id)
        {
            var Dep = _departmentRepository.Get(id);
            return Json(Dep, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int id)
        {
            _departmentRepository.Delete(id);
            return Json(JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(int id,DepartmentParam param)
        {
           
            _departmentRepository.Update(id,param);
            return Json(JsonRequestBehavior.AllowGet);
        }














        //public PartialViewResult Add()
        //{
        //    return PartialView();
        //}
        //public ActionResult Create()
        //{

        //   return View();
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(DepartmentParam param)
        //{
        //    _departmentRepository.Insert(param);
        //    return View(param);
        //}

        //public JsonResult ConfirmDelete(int Id)
        //{


        //    bool result = false;
        //    Department dep = db.Departments.SingleOrDefault(x => x.IsDelete == false && x.Id == Id);
        //    if (dep != null)
        //    {
        //        dep.IsDelete = true;
        //        db.SaveChanges();
        //        result = true;
        //    }

        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}
    }
}