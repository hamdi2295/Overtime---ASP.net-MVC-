using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUDModal.DataAccess.Context;
using CRUDModal.DataAccess.Models;
using CRUDModal.DataAccess.Params;

namespace CRUDModal.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult LoginPage()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Autherize(Employee userModel)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var userDetails = db.Employees.Where(x => x.Email == userModel.Email && x.Password == userModel.Password).FirstOrDefault();

                if (userDetails == null)
                {
                    return View("LoginPage", userModel);
                }
                else if (userDetails.Roles.Id == 1 && userDetails.IsDelete == false)
                {
                    Session["Id"] = userDetails.Id;
                    Session["Email"] = userDetails.Email;
                    Session["Role"] = userDetails.Roles.Id;
                    Session["FirstName"] = userDetails.FirstName;
                    Session["LastName"] = userDetails.LastName;
                    Session["Foto"] = userDetails.Foto ;
                    Session["Address"] = userDetails.Address;
                    Session["Department"] = userDetails.Departments.Name;

                    return RedirectToAction("UserProfile", "Login");
                }
                else if (userDetails.Roles.Id == 2 && userDetails.IsDelete == false)
                {
                    Session["Id"] = userDetails.Id;
                    Session["Email"] = userDetails.Email;
                    Session["Role"] = userDetails.Roles.Id;
                    Session["FirstName"] = userDetails.FirstName;
                    Session["LastName"] = userDetails.LastName;
                    Session["Foto"] = userDetails.Foto;
                    Session["Address"] = userDetails.Address;
                    Session["Department"] = userDetails.Departments.Name;

                    return RedirectToAction("UserProfile", "Login");
                }
                else if (userDetails.Roles.Id == 3 && userDetails.IsDelete == false)
                {
                    Session["Id"] = userDetails.Id;
                    Session["Email"] = userDetails.Email;
                    Session["Role"] = userDetails.Roles.Id;
                    Session["FirstName"] = userDetails.FirstName;
                    Session["LastName"] = userDetails.LastName;
                    Session["Foto"] = userDetails.Foto;
                    Session["Address"] = userDetails.Address;
                    Session["Department"] = userDetails.Departments.Name;

                    return RedirectToAction("UserProfile", "Login");
                }
                else if (userDetails.Roles.Id == 1 && userDetails.IsDelete == true || userDetails.Roles.Id == 2 && userDetails.IsDelete == true || userDetails.Roles.Id == 3 && userDetails.IsDelete == true)
                {
                    return View("LoginPage", userModel);
                }
                
            }
            return View();
        }
        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("LoginPage", "Login");
        }

        public ActionResult UserProfile()
        {
            return View();
        }
    }
}