﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Sınıflar;

namespace OnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        private Context context = new Context();
        public ActionResult Index()
        {
            var urunler = context.Uruns.ToList();
            return View(urunler);
        }
    }
}