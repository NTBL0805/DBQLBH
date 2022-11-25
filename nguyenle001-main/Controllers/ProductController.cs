using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;
using System.IO;

namespace WebBanHang.Controllers
{
    public class ProductController : Controller
    {
        DBQLBHEntities db = new DBQLBHEntities();
        // GET: Product
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }
        [HttpPost]
        public ActionResult Create(Products pro)
        {
            List<Category> list = db.Category.ToList();
            try
            {
                if (pro.UploadImage != null)
                {
                    string filename = Path.GetFileNameWithoutExtension(pro.UploadImage.FileName);
                    string extent = Path.GetExtension(pro.UploadImage.FileName);
                    filename = filename + extent;
                    pro.ImagePro = "~/Content/Iamge/" + filename;
                    pro.UploadImage.SaveAs(Path.Combine(Server.MapPath("~/Content/Iamge/"), filename));

                }
                ViewBag.listCategory = new SelectList(list, "IDCate", "NameCate", 1);
                db.Products.Add(pro);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }
        public ActionResult SelectCate()
        {
            Category se_cate = new Category();
            se_cate.ListCate = db.Category.ToList<Category>();
            return PartialView(se_cate);
                
        }
    }
}