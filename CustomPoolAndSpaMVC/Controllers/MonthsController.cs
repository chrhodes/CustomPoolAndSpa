using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

using CustomPoolAndSpa.Domain.Lookups;
using CustomPoolAndSpa.LookupData;

namespace CustomPoolAndSpaMVC.Controllers
{
    public class MonthsController : Controller
    {
        private CustomPoolAndSpaLookupsDbContext db = new CustomPoolAndSpaLookupsDbContext();

        // GET: Months
        public ActionResult Index()
        {
            return View(db.MonthsSet.ToList());
        }

        // GET: Months/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Months months = db.MonthsSet.Find(id);
            if (months == null)
            {
                return HttpNotFound();
            }
            return View(months);
        }

        // GET: Months/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Months/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DisplayMember")] Months months)
        {
            if (ModelState.IsValid)
            {
                db.MonthsSet.Add(months);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(months);
        }

        // GET: Months/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Months months = db.MonthsSet.Find(id);
            if (months == null)
            {
                return HttpNotFound();
            }
            return View(months);
        }

        // POST: Months/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DisplayMember")] Months months)
        {
            if (ModelState.IsValid)
            {
                db.Entry(months).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(months);
        }

        // GET: Months/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Months months = db.MonthsSet.Find(id);
            if (months == null)
            {
                return HttpNotFound();
            }
            return View(months);
        }

        // POST: Months/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Months months = db.MonthsSet.Find(id);
            db.MonthsSet.Remove(months);
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
