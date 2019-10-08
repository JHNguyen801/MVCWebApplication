using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FixedAssetsWebApp.Models;

namespace FixedAssetsWebApp.Controllers
{
    public class AssetsController : Controller
    {
        private FixedAssetsWebAppContext db = new FixedAssetsWebAppContext();

        // GET: Assets
        public ActionResult Index(string id)
        {
            var assets = from a in db.Assets
                         select a;

            if (!String.IsNullOrEmpty(id))
            {
                assets = assets.Where(s => s.AssetDescription.Contains(id) || s.Status.Contains(id));
            }
            return View(db.Assets.ToList());
        }

        // GET: Assets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assets assets = db.Assets.Find(id);
            if (assets == null)
            {
                return HttpNotFound();
            }
            return View(assets);
        }

        // GET: Assets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Assets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AssetID,AssetDescription,Category,TaxClassification,ServiceDate," +
            "Quantity,Cost,Location,TagNubmer,SerialNumber,Status,Department,Invoice,PO,Vendor")] Assets assets)
        {
            if (ModelState.IsValid)
            {
                db.Assets.Add(assets);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(assets);
        }

        // GET: Assets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assets assets = db.Assets.Find(id);
            if (assets == null)
            {
                return HttpNotFound();
            }
            return View(assets);
        }

        // POST: Assets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AssetID,AssetDescription,Category,TaxClassification,ServiceDate," +
            "Quantity,Cost,Location,TagNubmer,SerialNumber,Status,Department,Invoice,PO,Vendor")] Assets assets)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assets).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(assets);
        }

        // GET: Assets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assets assets = db.Assets.Find(id);
            if (assets == null)
            {
                return HttpNotFound();
            }
            return View(assets);
        }

        // POST: Assets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Assets assets = db.Assets.Find(id);
            db.Assets.Remove(assets);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
