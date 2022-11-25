using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;

namespace WebBanHang.Controllers
{
    public class LoginUserController : Controller
    {
        // GET: LoginUser
        DBQLBHEntities db = new DBQLBHEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]

        public ActionResult LoginAccount(AdminUser _user)
        {
            var check = db.AdminUser.Where(s => s.ID == _user.ID && s.PasswordUser == _user.PasswordUser).FirstOrDefault();

            if(check == null)
            {
                ViewBag.ErrorLogin = "Error Login";
                return View("Index");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(AdminUser user)
        {
            if(ModelState.IsValid)
            {
                db.AdminUser.Add(user);
                    db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorRegister = "Error Register";
                return View("Register");

            }
           
        }
        public ActionResult LogOutUser()
        {
            Session.Abandon();
            return RedirectToAction("Index", "LoginUser");
        }
    }
}