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
    public class ReceitasController : Controller
    {
        private CacarolaReceitaContext db = new CacarolaReceitaContext();

        // GET: Receitas
        [AllowAnonymous]
        public ActionResult Index()
        {
            var receita = db.Receita.Include(r => r.Categoria).Include(r => r.Dificuldade);
            return View(receita.ToList());
        }

        // GET: Receitas/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receita receita = db.Receita.Find(id);

            receita.ListaIngredientes = db.Ingrediente.Where(i => i.ReceitaID == id).ToList();

            if (receita == null)
            {
                return HttpNotFound();
            }

            ViewBag.Classificacao = Classificacao.CalcularAvaliacaoReceita(id);
            ViewBag.Receita = receita.NomeReceita;
            return View(receita);
        }

        // GET: Receitas/Create
        [Authorize(Roles = "Admin, User")]
        public ActionResult Create()
        {
            ViewBag.CategoriaID = new SelectList(db.Categoria, "CategoriaID", "NomeCategoria");
            ViewBag.DificuldadeID = new SelectList(db.Dificuldade, "DificuldadeID", "NomeDificuldade");
            
            return View();
        }

        // POST: Receitas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, User")]
        public ActionResult Create(Receita receita, List<Ingrediente> listaIngredientes)
        {
            if (ModelState.IsValid)
            {
                receita.UserID = User.Identity.Name;
                db.Receita.Add(receita);
                db.SaveChanges();

                Ingrediente.CriarListaIngredientes(receita.ReceitaID, listaIngredientes);

                return RedirectToAction("Index");
            }

            ViewBag.CategoriaID = new SelectList(db.Categoria, "CategoriaID", "NomeCategoria", receita.CategoriaID);
            ViewBag.DificuldadeID = new SelectList(db.Dificuldade, "DificuldadeID", "NomeDificuldade", receita.DificuldadeID);
            return View(receita);
        }

        // GET: Receitas/Edit/5
        [Authorize(Roles = "Admin, User")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receita receita = db.Receita.Find(id);
            receita.ListaIngredientes = db.Ingrediente.Where(i => i.ReceitaID == id).ToList();
            if (receita == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaID = new SelectList(db.Categoria, "CategoriaID", "NomeCategoria", receita.CategoriaID);
            ViewBag.DificuldadeID = new SelectList(db.Dificuldade, "DificuldadeID", "NomeDificuldade", receita.DificuldadeID);
            ViewBag.UnidadeMedidaID = new SelectList(db.UnidadeMedida, "UnidadeMedidaID", "Unidade");
            return View(receita);
        }

        // POST: Receitas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, User")]
        public ActionResult Edit(Receita receita, List<Ingrediente> listaIngredientes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(receita).State = EntityState.Modified;
                db.SaveChanges();
                Ingrediente.AtualizarListaIngredientes(listaIngredientes, receita.ReceitaID);
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaID = new SelectList(db.Categoria, "CategoriaID", "NomeCategoria", receita.CategoriaID);
            ViewBag.DificuldadeID = new SelectList(db.Dificuldade, "DificuldadeID", "NomeDificuldade", receita.DificuldadeID);
            return View(receita);
        }

        // GET: Receitas/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receita receita = db.Receita.Find(id);
            if (receita == null)
            {
                return HttpNotFound();
            }
            return View(receita);
        }

        // POST: Receitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Receita receita = db.Receita.Find(id);
            db.Receita.Remove(receita);
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
