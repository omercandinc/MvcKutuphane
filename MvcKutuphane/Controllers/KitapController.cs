using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class KitapController : Controller
    {
		// GET: Kitap
		DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index(string p)
        {
			var kitaplar = from k in db.TBLKITAP select k;
			if(!string.IsNullOrEmpty(p))
			{
				kitaplar = kitaplar.Where(x => x.AD.Contains(p));
			}
			//var kitaplar = db.TBLKITAP.ToList();
            return View(kitaplar.ToList());
        }
		[HttpGet]
		public ActionResult KitapEkle()
		{
			List<SelectListItem> deger1 = (from i in db.TBLKATEGORI.ToList()
										   select new SelectListItem
										   {
											   Text = i.AD,
											   Value = i.ID.ToString()
										   }).ToList();
			List<SelectListItem> deger2 = (from i in db.TBLYAZAR.ToList()
										   select new SelectListItem
										   {
											   Text = i.AD + ' ' + i.SOYAD,
											   Value = i.ID.ToString()
										   }).ToList();

			ViewBag.dgr1 = deger1;
			ViewBag.dgr2 = deger2;
			return View();
		}
		[HttpPost]
		public ActionResult KitapEkle(TBLKITAP p)
		{
			var ktg = db.TBLKATEGORI.Where(k => k.ID == p.TBLKATEGORI.ID).FirstOrDefault();
			var yzr = db.TBLYAZAR.Where(k => k.ID == p.TBLYAZAR.ID).FirstOrDefault();
			p.TBLKATEGORI = ktg;
			p.TBLYAZAR = yzr;
			db.TBLKITAP.Add(p);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult KitapSil(int id)
		{
			var degerler = db.TBLKITAP.Find(id);
			db.TBLKITAP.Remove(degerler);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult KitapGetir(int id)
		{
			var degerler = db.TBLKITAP.Find(id);
			List<SelectListItem> deger1 = (from i in db.TBLKATEGORI.ToList()
										   select new SelectListItem
										   {
											   Text = i.AD,
											   Value = i.ID.ToString()
										   }).ToList();
			List<SelectListItem> deger2 = (from i in db.TBLYAZAR.ToList()
										   select new SelectListItem
										   {
											   Text = i.AD + ' ' + i.SOYAD,
											   Value = i.ID.ToString()
										   }).ToList();
			ViewBag.dgr1 = deger1;
			ViewBag.dgr2 = deger2;

			return View("KitapGetir", degerler);
		}
		public ActionResult KitapGuncelle(TBLKITAP p)
		{
			var degerler = db.TBLKITAP.Find(p.ID);
			degerler.AD = p.AD;
			degerler.BASIMYIL = p.BASIMYIL;
			degerler.SAYFA = p.SAYFA;
			degerler.YAYINEVI = p.YAYINEVI;
			degerler.DURUM = true;
			var ktg = db.TBLKATEGORI.Where(k => k.ID == p.TBLKATEGORI.ID).FirstOrDefault();
			var yzr = db.TBLYAZAR.Where(k => k.ID == p.TBLYAZAR.ID).FirstOrDefault();
			degerler.KATEGORI = ktg.ID;
			degerler.YAZAR = yzr.ID;
			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}