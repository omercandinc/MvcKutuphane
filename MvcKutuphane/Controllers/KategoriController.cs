using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class KategoriController : Controller
    {
		// GET: Kategori
		DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
			var degerler = db.TBLKATEGORI.ToList();
            return View(degerler);
        }
		[HttpPost]
		public ActionResult KategoriEkle(TBLKATEGORI p)
		{
			db.TBLKATEGORI.Add(p);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		[HttpGet]
		public ActionResult KategoriEkle()
		{
			return View();
		}
		public ActionResult KategoriSil(int id)
		{
			var degerler = db.TBLKATEGORI.Find(id);
			db.TBLKATEGORI.Remove(degerler);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		public ActionResult KategoriGetir(int id)
		{
			var degerler = db.TBLKATEGORI.Find(id);
			return View("KategoriGetir", degerler);
		}
		public ActionResult KategoriGuncelle(TBLKATEGORI p)
		{
			var degerler = db.TBLKATEGORI.Find(p.ID);
			degerler.AD = p.AD;
			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}