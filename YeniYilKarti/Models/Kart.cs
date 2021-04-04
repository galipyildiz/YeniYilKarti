using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace YeniYilKarti.Models
{
    [Table("Kartlar")]
    public class Kart
    {
        public int Id { get; set; }
        public string Baslik { get; set; }

        [MaxLength(20),Required]
        public string GonderenAd { get; set; }

        [MaxLength(20),Required]
        public string AliciAd { get; set; }

        [Required]
        public string ResimYolu { get; set; }

        [MaxLength(55),Required]
        public string Mesaj1 { get; set; }

        [MaxLength(55)]
        public string Mesaj2 { get; set; }

        [MaxLength(55)]
        public string Mesaj3 { get; set; }

        [ForeignKey("User")]
        public virtual string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}