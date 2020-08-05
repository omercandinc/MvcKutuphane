using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class YazarController : Controller
    {
		// GET: Yazar
		DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
		public ActionResult Index()
		{
			var degerler = db.TBLYAZAR.ToList();
			return View(degerler);
		}
		[HttpGet]
		public ActionResult YazarEkle()
		{
			return View();
		}
		[HttpPost]
		public ActionResult YazarEkle(TBLYAZAR p)
		{
			var degerler = db.TBLYAZAR.Add(p);
			db.SaveChanges();
			return View();
		}
	}
}