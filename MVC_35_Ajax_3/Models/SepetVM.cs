using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_35_Ajax_3.Models
{
    public class SepetVM
    {
        public string UrunAdi { get; set; }
        public int UrunID { get; set; }
        public decimal Fiyat { get; set; }
        public short Adet { get; set; }
    }
}