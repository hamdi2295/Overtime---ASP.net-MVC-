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
    public class DataOvertimesController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        private readonly IDataOvertimeRepository _dataovertimeRepository;
        public DataOvertimesController(IDataOvertimeRepository data)
        {
            _dataovertimeRepository = data;
        }
        // GET: DataOvertimes
        public ActionResult Index()
        {
            var employee = db.Employees.Where(x => x.IsDelete == false).ToList();
            return View(employee);
        }
        public ActionResult DetailsOvertime(int? id)
        {
            var ot = db.DataOvertimes.Where(x => x.Employees.Id == id).ToList();

            ViewData["id"] = id;
            DataOvertimeParam param = new DataOvertimeParam();
            param.Employees = id.ToString();
            return View(ot);
        }
        public JsonResult TypeList()
        {
            List<OvertimeType> type = db.OverTimeTypes.OrderBy(x => x.Type).ToList();
            return Json(type, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(DataOvertimeParam param, int Types)
        {
            param.OvertimeTypes = Types.ToString();
            _dataovertimeRepository.Insert(param);
            return Json(JsonRequestBehavior.AllowGet);
        }
        
    }
}