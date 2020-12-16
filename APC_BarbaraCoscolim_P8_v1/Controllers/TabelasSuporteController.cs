using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APC_BarbaraCoscolim_P8_v1.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TabelasSuporteController : Controller
    {
        // GET: TabelasSuporte
        public ActionResult Index()
        {
            return View();
        }
    }
}