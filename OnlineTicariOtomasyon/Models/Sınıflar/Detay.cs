﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Sınıflar
{
    public class Detay
    {
        public int DetayID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string UrunAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(2000)]
        public string UrunBilgi { get; set; }

        public int UrunId { get; set; }
        public virtual Urun Urun { get; set; }

    }
}