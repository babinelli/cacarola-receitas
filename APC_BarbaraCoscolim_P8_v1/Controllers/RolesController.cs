using APC_BarbaraCoscolim_P8_v1.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APC_BarbaraCoscolim_P8_v1.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        // Declara o context da Identity DataBase
        ApplicationDbContext context;

        public RolesController() // Construtor
        {
            // instancia o context
            context = new ApplicationDbContext();
        }

        // GET: Roles/Index
        public ActionResult Index()
        {
            // Converte a base de dados em lista e passa para a view
            var Roles = context.Roles.ToList();
            return View(Roles);
        }

        // GET: Roles/Create
        public ActionResult Create()
        {
            var Role = new IdentityRole();
            return View(Role);
        }

        // POST: Roles/Create
        [HttpPost]
        public ActionResult Create(IdentityRole Role)
        {
            // Adiciona um novo role à base de dados, salva e redireciona para a view index
            context.Roles.Add(Role);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        

    }
}