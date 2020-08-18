using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;


namespace MvcKutuphane.Controllers
{
    public class PersonelController : Controller
    {
		// GET: Personel
		DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
		public ActionResult Index()
		{
			var degerler = db.TBLPERSONEL.ToList();
			return View(degerler);
		}
		[HttpPost]
		public ActionResult PersonelEkle(TBLPERSONEL p)
		{
			if(!ModelState.IsValid)
			{
				return View("PersonelEkle");
			}
			db.TBLPERSONEL.Add(p);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		[HttpGet]
		public ActionResult PersonelEkle()
		{
			return View();
		}
		public ActionResult PersonelSil(int id)
		{
			var degerler = db.TBLPERSONEL.Find(id);
			db.TBLPERSONEL.Remove(degerler);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		public ActionResult PersonelGetir(int id)
		{
			var degerler = db.TBLPERSONEL.Find(id);
			return View("PersonelGetir", degerler);
		}
		public ActionResult PersonelGuncelle(TBLPERSONEL p)
		{
			var degerler = db.TBLPERSONEL.Find(p.ID);
			degerler.PERSONEL = p.PERSONEL;
			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}