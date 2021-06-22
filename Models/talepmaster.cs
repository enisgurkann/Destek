using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Destek.Models
{
    public class talepmaster
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(100, ErrorMessage = "Lütfen {1} karakteri geçmeden yazın.")]
        [DisplayName("Talep Başlık")]
        [Required]
        public string Baslik { get; set; }

        [StringLength(1000, ErrorMessage = "Lütfen {1} karakteri geçmeden yazın.")]
        [DisplayName("Talep İçerik")]
        [Required]
        public string Icerik { get; set; }

        [DisplayName("Talep Cevap")]
        //[Required]
        public string Cevap { get; set; }

        [DisplayName("Talep Tipi")]
        [Required]
        public int Tipi { get; set; }

        [DisplayName("Aciliyet Durumu")]
        [Required]
        public int AciliyetDurumu { get; set; }

        [DisplayName("Onay Durumu")]
        //[Required]
        public string Onay { get; set; }


        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime BaslangicTarihi { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime BitisTarihi { get; set; }
        public int AtananKisi { get; set; }

          [DisplayName("Kayıt Tarih")]
        public DateTime GMT { get; set; }

        [DisplayName("Firma")]
        [Required]
        [Key]
        public int FırmaId { get; set; }

        public string Durum { get; set; }
    }
}