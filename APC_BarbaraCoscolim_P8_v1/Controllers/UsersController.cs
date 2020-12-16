using APC_BarbaraCoscolim_P8_v1.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APC_BarbaraCoscolim_P8_v1.Controllers
{
    public class UsersController : Controller
    {
        // Declara o context da Identity DataBase
        ApplicationDbContext context;

        public UsersController() // Construtor
        {
            // instancia o context
            context = new ApplicationDbContext();
        }

        // GET: Users
        public ActionResult Index()
        {
            var users = context.Users.ToList();
            return View(users);
        }

    }
}