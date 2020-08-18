using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcKutuphane.Controllers
{
    public class UyeController : Controller
    {
		// GET: Uye
		DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
		public ActionResult Index(int sayfa=1)
        {
			//var degerler = db.TBLUYELER.ToList();
			var degerler = db.TBLUYELER.ToList().ToPagedList(sayfa, 3);
			return View(degerler);
        }
		[HttpPost]
		public ActionResult UyeEkle(TBLUYELER p)
		{
			if (!ModelState.IsValid)
			{
				return View("UyeEkle");
			}
			db.TBLUYELER.Add(p);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		[HttpGet]
		public ActionResult UyeEkle()
		{
			return View();
		}

		public ActionResult UyeSil(int id)
		{
			var degerler = db.TBLUYELER.Find(id);
			db.TBLUYELER.Remove(degerler);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		public ActionResult UyeGetir(int id)
		{
			var degerler = db.TBLUYELER.Find(id);
			return View("UyeGetir", degerler);
		}
		public ActionResult UyeGuncelle(TBLUYELER p)
		{
			var degerler = db.TBLUYELER.Find(p.ID);
			degerler.AD = p.AD;
			degerler.SOYAD = p.SOYAD;
			degerler.MAIL = p.MAIL;
			degerler.KULLANICIADI = p.KULLANICIADI;
			degerler.SIFRE = p.SIFRE;
			degerler.OKUL = p.OKUL;
			degerler.TELEFON = p.TELEFON;
			degerler.FOTOGRAF = p.FOTOGRAF;
			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}