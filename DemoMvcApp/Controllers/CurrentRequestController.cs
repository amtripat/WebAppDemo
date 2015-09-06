using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DemoMvcApp.Models;

namespace DemoMvcApp.Controllers
{
    public class CurrentRequestController : Controller
    {
        private DemoMvcAppContext db = new DemoMvcAppContext();

        // GET: CurrentRequest
        public ActionResult Index()
        {
            return View(db.RequestModels.ToList());
        }

        // GET: CurrentRequest/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestModel requestModel = db.RequestModels.Find(id);
            if (requestModel == null)
            {
                return HttpNotFound();
            }
            return View(requestModel);
        }

        // GET: CurrentRequest/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CurrentRequest/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProcessId,TimeElapsed,TimeInModule,TimeInState,RequestId,CurrentDate")] RequestModel requestModel)
        {
            if (ModelState.IsValid)
            {
                db.RequestModels.Add(requestModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(requestModel);
        }

        // GET: CurrentRequest/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestModel requestModel = db.RequestModels.Find(id);
            if (requestModel == null)
            {
                return HttpNotFound();
            }
            return View(requestModel);
        }

        // POST: CurrentRequest/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProcessId,TimeElapsed,TimeInModule,TimeInState,RequestId,CurrentDate")] RequestModel requestModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(requestModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(requestModel);
        }

        // GET: CurrentRequest/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestModel requestModel = db.RequestModels.Find(id);
            if (requestModel == null)
            {
                return HttpNotFound();
            }
            return View(requestModel);
        }

        // POST: CurrentRequest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RequestModel requestModel = db.RequestModels.Find(id);
            db.RequestModels.Remove(requestModel);
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
