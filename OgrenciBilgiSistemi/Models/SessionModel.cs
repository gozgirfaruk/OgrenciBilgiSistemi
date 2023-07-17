using OgrenciBilgiSistemi.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OgrenciBilgiSistemi.Models
{
    public class SessionModel
    {
        public Ogrenci Ogrenci{ get; set; }
        public Akademisyen Akademisyen { get; set; }
        public string GosterimAdi { get; set; }
        public string GosterimUnvani { get; set; }
        public string Resim { get; set; }

    }
}