using System.Net;
using System.Web.Mvc;

using CustomPoolAndSpa.Domain.Lookups;

using VNC.Core.DomainServices;

namespace CustomPoolAndSpaMVC.Controllers
{
    public class ChlorineLevelsController : Controller
    {
        //private CustomPoolAndSpaLookupsDbContext db = new CustomPoolAndSpaLookupsDbContext();
        private ConnectedRepository<ChlorineLevel> _repository;

        public ChlorineLevelsController()
        {
            // TODO(crhodes)
            // Figure out how to register the dbContext.

            _repository = new ConnectedRepository<ChlorineLevel>(new CustomPoolAndSpa.LookupData.CustomPoolAndSpaLookupsDbContext());
        }

        // TODO(crhodes)
        // Figure out how to pass this in.

        //public ChlorineLevelsController(ConnectedRepository<ChlorineLevel> repository)
        //{
        //    _repository = repository;
        //}

        // GET: ChlorineLevels
        public ActionResult Index()
        {
            return View(_repository.All());
            //return View(db.ChlorineLevelSet.ToList());
        }

        // GET: ChlorineLevels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ChlorineLevel chlorineLevel = _repository.FindById(id.Value);
            //ChlorineLevel chlorineLevel = db.ChlorineLevelSet.Find(id);

            if (chlorineLevel == null)
            {
                return HttpNotFound();
            }
            return View(chlorineLevel);
        }

        // GET: ChlorineLevels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChlorineLevels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DisplayMember")] ChlorineLevel chlorineLevel)
        {
            if (ModelState.IsValid)
            {
                _repository.Insert(chlorineLevel);
                //db.ChlorineLevelSet.Add(chlorineLevel);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chlorineLevel);
        }

        // GET: ChlorineLevels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ChlorineLevel chlorineLevel = _repository.FindById(id.Value);
            //ChlorineLevel chlorineLevel = db.ChlorineLevelSet.Find(id);

            if (chlorineLevel == null)
            {
                return HttpNotFound();
            }

            return View(chlorineLevel);
        }

        // POST: ChlorineLevels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DisplayMember")] ChlorineLevel chlorineLevel)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(chlorineLevel);
                //db.Entry(chlorineLevel).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chlorineLevel);
        }

        // GET: ChlorineLevels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ChlorineLevel chlorineLevel = _repository.FindById(id.Value);
            //ChlorineLevel chlorineLevel = db.ChlorineLevelSet.Find(id);

            if (chlorineLevel == null)
            {
                return HttpNotFound();
            }
            return View(chlorineLevel);
        }

        // POST: ChlorineLevels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);
            //ChlorineLevel chlorineLevel = db.ChlorineLevelSet.Find(id);
            //db.ChlorineLevelSet.Remove(chlorineLevel);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
