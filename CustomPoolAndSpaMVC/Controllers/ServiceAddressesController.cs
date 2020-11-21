using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CustomPoolAndSpa.Data;
using CustomPoolAndSpa.Domain;

namespace CustomPoolAndSpaMVC.Controllers
{
    public class ServiceAddressesController : Controller
    {
        private CustomPoolAndSpaDbContext db = new CustomPoolAndSpaDbContext();

        // GET: ServiceAddresses
        public ActionResult Index()
        {
            return View(db.ServiceAddressSet.ToList());
        }

        // GET: ServiceAddresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceAddress serviceAddress = db.ServiceAddressSet.Find(id);
            if (serviceAddress == null)
            {
                return HttpNotFound();
            }
            return View(serviceAddress);
        }

        // GET: ServiceAddresses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServiceAddresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DateModified,DateCreated")] ServiceAddress serviceAddress)
        {
            if (ModelState.IsValid)
            {
                db.ServiceAddressSet.Add(serviceAddress);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(serviceAddress);
        }

        // GET: ServiceAddresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceAddress serviceAddress = db.ServiceAddressSet.Find(id);
            if (serviceAddress == null)
            {
                return HttpNotFound();
            }
            return View(serviceAddress);
        }

        // POST: ServiceAddresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DateModified,DateCreated")] ServiceAddress serviceAddress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(serviceAddress).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(serviceAddress);
        }

        // GET: ServiceAddresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceAddress serviceAddress = db.ServiceAddressSet.Find(id);
            if (serviceAddress == null)
            {
                return HttpNotFound();
            }
            return View(serviceAddress);
        }

        // POST: ServiceAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ServiceAddress serviceAddress = db.ServiceAddressSet.Find(id);
            db.ServiceAddressSet.Remove(serviceAddress);
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
