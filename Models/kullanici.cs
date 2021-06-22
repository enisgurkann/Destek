using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Destek.Models
{
    public class kullanici
    {
        public int Id { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string Status { get; set; } //A / P
    }
}