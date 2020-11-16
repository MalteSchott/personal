using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ModelViewer1.DAL;
using ModelViewer1.Models;

namespace ModelViewer1.Controllers
{
    public class BuildingController : Controller
    {
        private BuildingContext db = new BuildingContext();

        // GET: Building
        public ActionResult Index()
        {
            return View(db.Buildings.ToList());
        }

        public ViewResult ListBuildings()
        {
            return View(db.Buildings.ToList());
        }

        // GET: Building/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuildingModel buildingModel = db.Buildings.Find(id);
            if (buildingModel == null)
            {
                return HttpNotFound();
            }
            return View(buildingModel);
        }

        // GET: Building/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Building/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Architect")] BuildingModel buildingModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Buildings.Add(buildingModel);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException dex)
            {
                //Log the error 
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(buildingModel);
        }

        // GET: Building/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuildingModel buildingModel = db.Buildings.Find(id);
            if (buildingModel == null)
            {
                return HttpNotFound();
            }
            return View(buildingModel);
        }

        // POST: Building/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Architect")] BuildingModel buildingModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(buildingModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(buildingModel);
        }

        // GET: Building/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuildingModel buildingModel = db.Buildings.Find(id);
            if (buildingModel == null)
            {
                return HttpNotFound();
            }
            return View(buildingModel);
        }

        // POST: Building/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BuildingModel buildingModel = db.Buildings.Find(id);
            db.Buildings.Remove(buildingModel);
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
