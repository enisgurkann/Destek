using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Destek.Models
{
    public class musteri
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Kodu { get; set; }

        [StringLength(100, ErrorMessage = "Lütfen {1} karakteri geçmeden yazın.")]
        [DisplayName("Ünvan")]
        [Required]
        public string Unvan { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }

        [StringLength(50, ErrorMessage = "Lütfen {1} karakteri geçmeden yazın.")]
        [DisplayName("Kullanıcı Adı")]
        [Required]
        public string KullaniciAdi { get; set; }

        [StringLength(50, ErrorMessage = "Lütfen {1} karakteri geçmeden yazın.")]
        [DisplayName("Şifre")]
        [Required]
        public string Sifre { get; set; }
        [Required]
        public string Durum { get; set; }
        public string LogoUrl { get; set; }

        public string Yonetici { get; set; } // E | H
    }
}