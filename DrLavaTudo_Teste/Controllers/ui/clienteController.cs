using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DrLavaTudo_Teste.Controllers.ui
{
    public class clienteController : Controller
    {
        //Controle criado para a UI Cliente
        public ActionResult Index()
        {
            ViewBag.Title = "Cliente";

            return View();
        }
    }
}