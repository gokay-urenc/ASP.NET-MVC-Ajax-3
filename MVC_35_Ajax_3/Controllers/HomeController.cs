using MVC_35_Ajax_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_35_Ajax_3.Controllers
{
    public class HomeController : Controller
    {
        NORTHWND db = new NORTHWND();
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        public ActionResult _UrunGetir(int id)
        {
            List<Product> urunListesi = db.Products.Where(x => x.CategoryID == id).ToList();
            return PartialView(urunListesi);
        }
    }
}