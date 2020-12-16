using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APC_BarbaraCoscolim_P8_v1.Models;

namespace APC_BarbaraCoscolim_P8_v1.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Caçarola Receitas";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Bárbara Fantinelli Coscolim";

            return View();
        }

        public JsonResult IfUserExists(string email)
        {
            return Json(!db.Users.Any(XmlSiteMapProvider => XmlSiteMapProvider.Email == email), JsonRequestBehavior.AllowGet);
        }
    }
}