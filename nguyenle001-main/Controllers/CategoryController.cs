using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;


namespace WebBanHang.Controllers
{
    public class CategoryController : Controller
    {
        DBQLBHEntities db = new DBQLBHEntities();
        // GET: Category
        public ActionResult Index(string _name)
        {
            var search = from s in db.Category
                         select s;
            if (!string.IsNullOrEmpty(_name))
            {
                search = search.Where(s => s.NameCate.Contains(_name));
            }
            return View(search);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category cate)
        {
            db.Category.Add(cate);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int Id)
        {
            return View(db.Category.Where(s => s.Id == Id).FirstOrDefault());
        }
        public ActionResult Edit(int Id)
        {
            return View(db.Category.Where(s => s.Id == Id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(int Id, Category cate)
        {
            db.Entry(cate).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int Id)
        {
            return View(db.Category.Where(s => s.Id == Id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(int Id, Category cate)
        {
            try
            {
                cate=db.Category.Where(s=>s.Id==Id).FirstOrDefault();
                db.Category.Remove(cate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("this data is using in other table, ERROR DELETE !");
            }
        }
       
    }
}