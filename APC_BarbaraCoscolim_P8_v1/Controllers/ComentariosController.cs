using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using APC_BarbaraCoscolim_P8_v1.Models;
using System.Web.Routing;

namespace APC_BarbaraCoscolim_P8_v1.Controllers
{
    public class ComentariosController : Controller
    {
        private CacarolaReceitaContext db = new CacarolaReceitaContext();

        // GET: Comentarios
        [Authorize(Roles = "Admin")] // Não faz sentido o user ver a tabela de comentários de todas as receitas
        public ActionResult Index()
        {
            var comentario = db.Comentario.Include(c => c.Receita);
            return View(comentario.ToList());
        }

        [AllowAnonymous]
        public ActionResult _Index()
        {
            var comentario = db.Comentario.Include(c => c.Receita);
            return View(comentario.ToList());
        }

        // GET: Comentarios/Create
        [Authorize(Roles = "Admin, User")]
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                ViewBag.ReceitaID = new SelectList(db.Receita, "ReceitaID", "UserID");

                Comentario comentario = new Comentario();
                comentario.ReceitaID = (int)id;
                comentario.UserID = User.Identity.Name;
                return View(comentario);
            }
            
        }

        // POST: Comentarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, User")]
        public ActionResult Create([Bind(Include = "ComentarioID,ReceitaID,UserID,TextoComentario")] Comentario comentario)
        {
            if (ModelState.IsValid)
            {
                db.Comentario.Add(comentario);
                db.SaveChanges();
                // Cria um par chave-valor, com "id" - ReceitaID
                var routeValue = new RouteValueDictionary();
                routeValue.Add("id", comentario.ReceitaID);

                // Após adicionar o comentário, volta para os detalhes da receita
                return RedirectToAction("Details", "Receitas", routeValue);
            }
            
            ViewBag.ReceitaID = new SelectList(db.Receita, "ReceitaID", "UserID", comentario.ReceitaID);
            return View(comentario);
        }

        // GET: Comentarios/Edit/5
        [Authorize(Roles = "Admin, User")]
        public ActionResult Edit(int? idReceita, int? idComentario)
        {
            if (idReceita == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comentario comentario = db.Comentario.Where(r => r.ReceitaID == idReceita && r.ComentarioID == idComentario && r.UserID == User.Identity.Name).Select(r => r).First();
            if (comentario == null)
            {
                return HttpNotFound();
            }
            ViewBag.ReceitaID = new SelectList(db.Receita, "ReceitaID", "UserID", comentario.ReceitaID);
            return View(comentario);
        }

        // POST: Comentarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, User")]
        public ActionResult Edit([Bind(Include = "ComentarioID,ReceitaID,UserID,TextoComentario")] Comentario comentario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comentario).State = EntityState.Modified;
                db.SaveChanges();

                // Cria um par chave-valor, com "id" - ReceitaID
                var routeValue = new RouteValueDictionary();
                routeValue.Add("id", comentario.ReceitaID);

                // Após adicionar a classificação, volta para os detalhes da receita
                return RedirectToAction("Details", "Receitas", routeValue);
            }
            ViewBag.ReceitaID = new SelectList(db.Receita, "ReceitaID", "UserID", comentario.ReceitaID);
            return View(comentario);
        }

        // GET: Comentarios/Delete/5
        [Authorize(Roles = "Admin, User")]
        public ActionResult Delete(int? idReceita, int? idComentario)
        {
            if (idReceita == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comentario comentario = db.Comentario.Where(r => r.ReceitaID == idReceita && r.ComentarioID == idComentario).Select(r => r).First();
            if (comentario == null)
            {
                return HttpNotFound();
            }
            return View(comentario);
        }

        // POST: Comentarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, User")]
        public ActionResult DeleteConfirmed(int idReceita, int idComentario)
        {
            Comentario comentario = db.Comentario.Where(r => r.ReceitaID == idReceita && r.ComentarioID == idComentario).Select(r => r).First();
            db.Comentario.Remove(comentario);
            db.SaveChanges();

            // Cria um par chave-valor, com "id" - ReceitaID
            var routeValue = new RouteValueDictionary();
            routeValue.Add("id", comentario.ReceitaID);

            // Após adicionar a classificação, volta para os detalhes da receita
            return RedirectToAction("Details", "Receitas", routeValue);
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
