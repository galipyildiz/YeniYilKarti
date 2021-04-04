using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YeniYilKarti.Models
{
    public class KartVM
    {
        [MaxLength(20, ErrorMessage = "Gönderen Adı Max uzunluk 20 karakterdir."), Required(ErrorMessage = "Gönderen adı zorunludur")]
        public string GonderenAd { get; set; }

        [MaxLength(20,ErrorMessage = "Alıcı Adı Max uzunluk 20 karakterdir."), Required(ErrorMessage = "Alıcı adı zorunludur")]
        public string AliciAd { get; set; }

        [Required(ErrorMessage = "Resim seçmelisiniz")]
        public string Resimyolu { get; set; }

        [Required(ErrorMessage ="Mesaj alanı zorunludur"),MaxLength(165,ErrorMessage ="Mesaj Alanı Max uzunluk 165 karakterdir.")]
        public string Mesaj { get; set; }

    }
}