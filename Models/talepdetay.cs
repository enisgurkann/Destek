using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Destek.Models
{
    public class talepdetay 
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Key]
        public int MasterId { get; set; }
        [StringLength(100, ErrorMessage = "Lütfen {1} karakteri geçmeden yazın.")]
        [DisplayName("Talep Başlık")]
        [Required]
        public string Aciklama { get; set; }
    }
}