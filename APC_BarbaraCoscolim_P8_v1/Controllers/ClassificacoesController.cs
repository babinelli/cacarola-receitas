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
    public class ClassificacoesController : Controller
    {
        private CacarolaReceitaContext db = new CacarolaReceitaContext();

        // GET: Classificacoes
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var classificacao = db.Classificacao.Include(c => c.Receita);
            return View(classificacao.ToList());
        }

        // GET: Classificacoes/Create
        [Authorize(Roles = "Admin, User")]
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.ReceitaID = new SelectList(db.Receita, "ReceitaID", "UserID");
            Classificacao classificacao = new Classificacao();
            classificacao.ReceitaID = (int)id;
            classificacao.UserID = User.Identity.Name;

            var avaliacoesUser = db.Classificacao.Where(c =>c.ReceitaID == id && c.UserID == User.Identity.Name).Count();

            if (avaliacoesUser == 0) 
            {
                return View(classificacao);
            }
            else // Caso a pessoa já tenha avaliado a receita, direciona para editar avaliação
            {
                // Cria um par chave-valor, com "id" - ReceitaID
                var routeValue = new RouteValueDictionary();
                routeValue.Add("idReceita", classificacao.ReceitaID);

                // Após adicionar a classificação, volta para os detalhes da receita
                return RedirectToAction("Edit", "Classificacoes", routeValue);
            }
            
        }

        // POST: Classificacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, User")]
        public ActionResult Create([Bind(Include = "ClassificacaoID,ReceitaID,NotaClassificacao,UserID")] Classificacao classificacao)
        {
            if (ModelState.IsValid)
            {
                db.Classificacao.Add(classificacao);
                db.SaveChanges();

                // Cria um par chave-valor, com "id" - ReceitaID
                var routeValue = new RouteValueDictionary();
                routeValue.Add("id", classificacao.ReceitaID);

                // Após adicionar a classificação, volta para os detalhes da receita
                return RedirectToAction("Details", "Receitas", routeValue);
            }

            ViewBag.ReceitaID = new SelectList(db.Receita, "ReceitaID", "UserID", classificacao.ReceitaID);
            return View(classificacao);
        }

        // GET: Classificacoes/Edit/5
        [Authorize(Roles = "Admin, User")]
        public ActionResult Edit(int? idReceita)
        {
            if (idReceita == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classificacao classificacao = db.Classificacao.Where(r => r.ReceitaID == idReceita && r.UserID == User.Identity.Name).Select(r => r).First();
            if (classificacao == null)
            {
                return HttpNotFound();
            }
            ViewBag.ReceitaID = new SelectList(db.Receita, "ReceitaID", "UserID", classificacao.ReceitaID);
            return View(classificacao);
        }

        // POST: Classificacoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, User")]
        public ActionResult Edit([Bind(Include = "ClassificacaoID,ReceitaID,NotaClassificacao,UserID")] Classificacao classificacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classificacao).State = EntityState.Modified;
                db.SaveChanges();

                // Cria um par chave-valor, com "id" - ReceitaID
                var routeValue = new RouteValueDictionary();
                routeValue.Add("id", classificacao.ReceitaID);

                // Após adicionar a classificação, volta para os detalhes da receita
                return RedirectToAction("Details", "Receitas", routeValue);
            }
            ViewBag.ReceitaID = new SelectList(db.Receita, "ReceitaID", "UserID", classificacao.ReceitaID);
            return View(classificacao);
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
