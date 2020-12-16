using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using APC_BarbaraCoscolim_P8_v1.Models;

namespace APC_BarbaraCoscolim_P8_v1.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DificuldadesController : Controller
    {
        private CacarolaReceitaContext db = new CacarolaReceitaContext();

        // GET: Dificuldades
        public ActionResult Index()
        {
            return View(db.Dificuldade.ToList());
        }

        // GET: Dificuldades/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dificuldades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DificuldadeID,NomeDificuldade")] Dificuldade dificuldade)
        {
            if (ModelState.IsValid)
            {
                db.Dificuldade.Add(dificuldade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dificuldade);
        }

        // GET: Dificuldades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dificuldade dificuldade = db.Dificuldade.Find(id);
            if (dificuldade == null)
            {
                return HttpNotFound();
            }
            return View(dificuldade);
        }

        // POST: Dificuldades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DificuldadeID,NomeDificuldade")] Dificuldade dificuldade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dificuldade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dificuldade);
        }

        // GET: Dificuldades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dificuldade dificuldade = db.Dificuldade.Find(id);
            if (dificuldade == null)
            {
                return HttpNotFound();
            }
            return View(dificuldade);
        }

        // POST: Dificuldades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dificuldade dificuldade = db.Dificuldade.Find(id);
            db.Dificuldade.Remove(dificuldade);
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
