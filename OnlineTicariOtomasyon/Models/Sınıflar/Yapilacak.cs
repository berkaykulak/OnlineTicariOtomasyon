﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Sınıflar
{
    public class Yapilacak
    {
        [Key]
        public int YapilacakId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string Baslik { get; set; }

        [Column(TypeName = "bit")]
        public bool Durum { get; set; }
        public int UrunId { get; set; }
        public virtual Urun Urun { get; set; }
    }
}