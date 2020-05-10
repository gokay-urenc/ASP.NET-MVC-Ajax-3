using MVC_35_Ajax_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_35_Ajax_3.Controllers
{
    public class UrunController : Controller
    {
        NORTHWND db = new NORTHWND();
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        public ActionResult SepeteEkle(int id)
        {
            // Sepet işleminde önce gelen ID'ye ait ürünü buluyoruz.
            List<SepetVM> sepetListesi = new List<SepetVM>();
            if (Session["sepetim"] != null) // Öncelikle daha önceden ürün eklenmiş mi diye session'u kontrol ediyoruz.
            {
                sepetListesi = Session["sepetim"] as List<SepetVM>;
            }
            SepetVM kontrolUrun = sepetListesi.FirstOrDefault(x => x.UrunID == id); // Sepete eklenmeye çalışılan ürün daha önceden sessionda var mı, yok mu kontrolü için listeye göz atıyoruz. Var ise adetini arttıralım yok ise yeni ekleyelim.
            if (kontrolUrun != null) // Bu ürün daha önceden eklenmiş ise adet arttırıyoruz.
            {
                kontrolUrun.Adet++;
            }
            else // Ürün ilk kez ekleniyorsa adeti bir olarak ekle.
            {
                Product bulunanUrun = db.Products.Find(id);
                SepetVM eklenenUrun = new SepetVM();
                eklenenUrun.UrunAdi = bulunanUrun.ProductName;
                eklenenUrun.UrunID = bulunanUrun.ProductID;
                eklenenUrun.Fiyat = bulunanUrun.UnitPrice.Value;
                eklenenUrun.Adet = 1;
                sepetListesi.Add(eklenenUrun);
            }
            Session["sepetim"] = sepetListesi;
            return Json(sepetListesi, JsonRequestBehavior.AllowGet);
        }
    }
}