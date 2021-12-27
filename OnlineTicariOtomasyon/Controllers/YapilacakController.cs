﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Sınıflar;

namespace OnlineTicariOtomasyon.Controllers
{
    public class YapilacakController : Controller
    {
        // GET: Yapilacak
        private Context context = new Context();
        public ActionResult Index()
        {
            var deger1 = context.Carilers.Count().ToString();
            ViewBag.d1 = deger1;
            var deger2 = context.Uruns.Count().ToString();
            ViewBag.d2 = deger2;
            var deger3 = context.Kategoris.Count().ToString();
            ViewBag.d3 = deger3;
            //var deger4 = context.Carilers.Distinct().Count(x=>x.CariSehir).ToString();
            return View();
        }
    }
}