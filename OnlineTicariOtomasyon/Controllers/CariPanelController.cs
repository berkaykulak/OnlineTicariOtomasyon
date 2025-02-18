﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using OnlineTicariOtomasyon.Models.Sınıflar;

namespace OnlineTicariOtomasyon.Controllers
{
    public class CariPanelController : Controller
    {
        private Context context = new Context();

        [Authorize]
        public ActionResult Index()
        {
            var carimail = (string) Session["CariMail"];
            //var degerler = context.Carilers.FirstOrDefault(x => x.CariMail == carimail);
            var degerler = context.Carilers.Where(x => x.CariMail == carimail).ToList();
            ViewBag.m = carimail;
            var mailid = context.Carilers.Where(x => x.CariMail == carimail).Select(y => y.CariId).FirstOrDefault();
            ViewBag.mid = mailid;
            var toplamSatis = context.SatisHarekets.Where(x => x.CariId == mailid).Count();
            ViewBag.toplamSatis = toplamSatis;
            var toplamTutar = context.SatisHarekets.Where(x => x.CariId == mailid).Sum(y => y.ToplamTutar);
            ViewBag.toplamTutar = toplamTutar;
            var toplamUrunSayisi = context.SatisHarekets.Where(x => x.CariId == mailid).Sum(y => y.Adet);
            ViewBag.toplamUrunSayisi = toplamUrunSayisi;
            var adsoyad = context.Carilers.Where(x => x.CariMail == carimail).Select(y => y.CariAd + " "+y.CariSoyad).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;
            return View(degerler);
        }

        public ActionResult Siparislerim()
        {
            var carimail = (string)Session["CariMail"];
            var id = context.Carilers.Where(x => x.CariMail == carimail.ToString()).Select(y=>y.CariId).FirstOrDefault();
            var degerler = context.SatisHarekets.Where(x => x.CariId == id).ToList();
            return View(degerler);
        }

        public ActionResult KargoTakip(string p)
        {
            var k = from x in context.KargoDetays select x;
            if (!string.IsNullOrEmpty(p))
            {
                k = k.Where(y => y.TakipKodu.Contains(p));
            }
            return View(k.ToList());
        }

        public ActionResult CariKargoTakip(string id)
        {
            var degerler = context.KargoTakips.Where(x => x.TakipKodu == id).ToList();
            return View(degerler);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}