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
    public class UnidadeMedidasController : Controller
    {
        private CacarolaReceitaContext db = new CacarolaReceitaContext();

        // GET: UnidadeMedidas
        public ActionResult Index()
        {
            return View(db.UnidadeMedida.ToList());
        }

        // GET: UnidadeMedidas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnidadeMedida unidadeMedida = db.UnidadeMedida.Find(id);
            if (unidadeMedida == null)
            {
                return HttpNotFound();
            }
            return View(unidadeMedida);
        }

        // GET: UnidadeMedidas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UnidadeMedidas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UnidadeMedidaID,Unidade,Descricao")] UnidadeMedida unidadeMedida)
        {
            if (ModelState.IsValid)
            {
                db.UnidadeMedida.Add(unidadeMedida);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(unidadeMedida);
        }

        // GET: UnidadeMedidas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnidadeMedida unidadeMedida = db.UnidadeMedida.Find(id);
            if (unidadeMedida == null)
            {
                return HttpNotFound();
            }
            return View(unidadeMedida);
        }

        // POST: UnidadeMedidas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UnidadeMedidaID,Unidade,Descricao")] UnidadeMedida unidadeMedida)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unidadeMedida).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(unidadeMedida);
        }

        // GET: UnidadeMedidas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnidadeMedida unidadeMedida = db.UnidadeMedida.Find(id);
            if (unidadeMedida == null)
            {
                return HttpNotFound();
            }
            return View(unidadeMedida);
        }

        // POST: UnidadeMedidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UnidadeMedida unidadeMedida = db.UnidadeMedida.Find(id);
            db.UnidadeMedida.Remove(unidadeMedida);
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
