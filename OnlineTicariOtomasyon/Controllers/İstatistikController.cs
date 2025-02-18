﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Sınıflar;

namespace OnlineTicariOtomasyon.Controllers
{
    public class İstatistikController : Controller
    {
        // GET: İstatistik
        private Context c = new Context();
        public ActionResult Index()
        {
            // Carileri Say
            var deger1 = c.Carilers.Count().ToString();
            ViewBag.d1 = deger1;

            // Urunleri Say
            var deger2 = c.Uruns.Count().ToString();
            ViewBag.d2 = deger2;

            // Personelleri Say
            var deger3 = c.Personels.Count().ToString();
            ViewBag.d3 = deger3;

            // Kategorileri Say
            var deger4 = c.Kategoris.Count().ToString();
            ViewBag.d4 = deger4;

            // ürünlerdeki stok sayısının toplamı
            var deger5 = c.Uruns.Sum(x=>x.Stok).ToString();
            ViewBag.d5 = deger5;

            //Kaç Çeşit Marka Var
            var deger6 = (from x in c.Uruns select x.Marka).Distinct().Count();
            ViewBag.d6 = deger6;

            //Stok sayısı 20 nin altında olan ürün sayısı
            var deger7 = c.Uruns.Count(x => x.Stok <= 20).ToString();
            ViewBag.d7 = deger7;

            // max fiyatlı ürün
            var deger8 = (from x in c.Uruns orderby x.SatisFiyat descending select x.UrunAd).FirstOrDefault();
            ViewBag.d8 = deger8;

            //min fiyatlı ürün
            var deger9 = (from x in c.Uruns orderby x.SatisFiyat ascending select x.UrunAd).FirstOrDefault();
            ViewBag.d9 = deger9;

            // Buzdolabı sayısı
            var deger10 = c.Uruns.Count(x => x.UrunAd == "Buzdolabı").ToString();
            ViewBag.d10 = deger10;

            // Laptop sayısı
            var deger11 = c.Uruns.Count(x => x.UrunAd == "Laptop").ToString();
            ViewBag.d11 = deger11;

            // En Çok Olan Markanın Adı
            var deger12 = c.Uruns.GroupBy(x => x.Marka).
                OrderByDescending(z => z.Count()).Select(y => y.Key)
                .FirstOrDefault();
            ViewBag.d12 = deger12;

            // En Çok Satan Ürün
            var deger13 =c.Uruns.Where(u=>u.UrunId==(c.SatisHarekets.GroupBy(x => x.UrunId).OrderByDescending(z => z.Count()).Select(y => y.Key)
                .FirstOrDefault())).Select(k=>k.UrunAd).FirstOrDefault();
            ViewBag.d13 = deger13;

            // Kasadaki Tutar
            var deger14 = c.SatisHarekets.Sum(x => x.ToplamTutar).ToString();
            ViewBag.d14 = deger14;

            // Bugünkü Satışlar
            var deger15 = c.SatisHarekets.Count(x => x.Tarih == DateTime.Today).ToString();
            ViewBag.d15 = deger15;

            //Bugünkü Kasa Tutarı
            if (Convert.ToInt32(deger15) != 0)
            {

                var deger16 = c.SatisHarekets.Where(x => x.Tarih == DateTime.Today).Sum(y => y.ToplamTutar).ToString();
                ViewBag.d16 = deger16;

            }
            else
            {
                ViewBag.d16 = deger15;
            }

            return View();
        }

        public ActionResult KolayTablolar()
        {
            var sorgu = from x in c.Carilers
                group x by x.CariSehir
                into g
                select new SinifGroup()
                {
                    Sehir = g.Key,
                    Sayi = g.Count()
                };

            return View(sorgu.ToList());
        }

        public PartialViewResult Partial1()
        {
            var sorgu2 = from x in c.Personels
                group x by x.Departman.DepartmanAd
                into g
                select new SinifGroup2
                {
                    Departman = g.Key,
                    Sayi = g.Count()
                };
            return PartialView(sorgu2.ToList());
        }

        public PartialViewResult Partial2()
        {
            var sorgu3 = c.Carilers.ToList();
            return PartialView(sorgu3);
        }

        public PartialViewResult Partial3()
        {
            var sorgu4 = c.Uruns.ToList();
            return PartialView(sorgu4);
        }

        public PartialViewResult Partial4()
        {
            var sorgu5 = from x in c.Uruns
                group x by x.Marka
                into g
                select new SinifGroup3
                {
                    Marka = g.Key,
                    Sayi = g.Count()
                };
            return PartialView(sorgu5.ToList());
        }
    }
}