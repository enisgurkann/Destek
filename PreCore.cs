using Destek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Destek
{
    public class PreCore
    {
        //* Cari *//   
        public bool CariYoneticiDurumu()
        {
            var Cari = CariVer();
            if (Cari.Yonetici != "H")
                return true;
            else
                return false;
        }
        public bool CariLoginDurumu()
        {
            var Cari = CariVer();
            if (Cari != null)
                return true;
            else
                return false;
        }
        public string CariUnvaniVer()
        {
            musteri Cari = CariVer();
            if (Cari != null)
                return Cari.Unvan.ToString();
            else
                return "Giriş Yapın";
        }
        public string CariKoduVer()
        {
            musteri Cari = CariVer();
            if (Cari != null)
                return Cari.Kodu.ToString();
            else
                return "MISAFIR";
        }

        public musteri CariVer()
        {
            var model = HttpContext.Current.Session["musteri"];
            if (model != null)
                return (musteri)model;
            else
                return null;
        }

        public ayarlar FirmaAyarlari()
        {
            return new ayarlar() { 
                Title = "Enestek",
                ZopimAdres = "",
                ZopimStatus = "E"
            };
        }
        public kullanici AdminVer()
        {
            var model = HttpContext.Current.Session["kullanici"];
            if (model != null)
                return (kullanici)model;
            else
                return null;
        }
        public bool AdminDurum()
        {
            var model = HttpContext.Current.Session["kullanici"];
            if (model != null)
                return  true;
            else
                return false;
        }
    }
}