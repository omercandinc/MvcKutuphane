using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class OduncController : Controller
    {
		// GET: Odunc
		DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
		public ActionResult Index()
        {
			var degerler = db.TBLHAREKET.ToList();
			return View(degerler);
        }
		[HttpGet]
		public ActionResult OduncVer()
		{
			return View();
		}

		[HttpPost]
		public ActionResult OduncVer(TBLHAREKET p)
		{
			db.TBLHAREKET.Add(p);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		public ActionResult OduncIade(int id)
		{
			var odn = db.TBLHAREKET.Find(id);
			return View("OduncIade",odn);
		}
		public ActionResult OduncGuncelle (TBLHAREKET p)
		{
			var hrk = db.TBLHAREKET.Find(p.ID);
			hrk.UYEGETIRTARIH = p.UYEGETIRTARIH;
			hrk.ISLEMDURUM = true;
			db.SaveChanges();
			return RedirectToAction("Index");
		}

	}
}