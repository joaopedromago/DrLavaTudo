using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace drlavatudo.Controllers
{
    public class HomeController : Controller
    {
        //Controle criado para a UI Home/Index
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
