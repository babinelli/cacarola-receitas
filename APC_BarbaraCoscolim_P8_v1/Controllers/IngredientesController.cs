using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using APC_BarbaraCoscolim_P8_v1.Models;

namespace APC_BarbaraCoscolim_P8_v1.Controllers
{
    [Authorize(Roles = "Admin, User")]
    public class IngredientesController : Controller
    {
        private CacarolaReceitaContext db = new CacarolaReceitaContext();

        public ActionResult Index()
        {
            var ingrediente = db.Ingrediente.Include(i => i.UnidadeMedida).Include(i => i.Receita);

            return View(ingrediente.ToList());
        }

        public ActionResult _Create(int? i)
        {
            ViewBag.i = i;
            ViewBag.UnidadeMedidaID = new SelectList(db.UnidadeMedida, "UnidadeMedidaID", "Unidade");

            return PartialView();
        }

        // POST: Ingredientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IngredienteID,ReceitaID,UnidadeMedidaID,Nome,Quantidade")] Ingrediente ingrediente)
        {
            if (ModelState.IsValid)
            {
                db.Ingrediente.Add(ingrediente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UnidadeMedidaID = new SelectList(db.UnidadeMedida, "UnidadeMedidaID", "Unidade", ingrediente.UnidadeMedidaID);
            return View(ingrediente);
        }

        public ActionResult _Edit(int? i, int? idIngrediente, int? receitaId)
        {
            ViewBag.i = i;
            ViewBag.UnidadeMedidaID = new SelectList(db.UnidadeMedida, "UnidadeMedidaID", "Unidade");
            ViewBag.ReceitaID = receitaId;

            Ingrediente ingrediente;
            if (idIngrediente != null)
            {
                ingrediente = db.Ingrediente.Find(idIngrediente);
            } 
            else
            {
                ingrediente = new Ingrediente();
            }
            
            return PartialView(ingrediente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IngredienteID,ReceitaID,UnidadeMedidaID,Nome,Quantidade")] Ingrediente ingrediente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ingrediente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UnidadeMedidaID = new SelectList(db.UnidadeMedida, "UnidadeMedidaID", "Unidade", ingrediente.UnidadeMedidaID);
            return View(ingrediente);
        }

        public ActionResult Delete(int? ingredienteId, int? receitaId)
        {
            // Cria um par chave-valor, com "id" - ReceitaID
            var routeValue = new RouteValueDictionary();
            routeValue.Add("id", receitaId);

            if (ingredienteId != null)
            {
                Ingrediente ingrediente = db.Ingrediente.Find(ingredienteId);
                if (ingrediente != null)
                {
                    // Cria um par chave-valor, com "id" - ReceitaID
                    var routeValue2 = new RouteValueDictionary();
                    routeValue2.Add("id", ingrediente.ReceitaID);

                    // Deleto o ingrediente da receita
                    Ingrediente.DeletarIngrediente(ingrediente.IngredienteID);

                    return RedirectToAction("Edit", "Receitas", routeValue2);
                }
            }         

            return RedirectToAction("Edit", "Receitas", routeValue);
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
