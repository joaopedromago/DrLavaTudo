using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DrLavaTudo_Teste.Controllers.ui
{
    public class osController : Controller
    {
        //Controle criado para a UI Os
        public ActionResult Index()
        {
            ViewBag.Title = "Ordem de Serviço";

            return View();
        }
    }
}