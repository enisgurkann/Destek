using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Destek.Models
{
    public class HomeModel
    {
        public int BekleyenTalepSayisi { get; set; }
        public int AktifYeniIstekSayisi { get; set; }
        public int AktifHataTalebiSayisi { get; set; }
        public int CevaplananAcikTalepSayisi { get; set; }
    }
}