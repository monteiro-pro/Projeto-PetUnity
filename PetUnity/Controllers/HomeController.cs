using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteUnitatio;

namespace PetUnity.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //** Chamando o teste de integração.
            //TestUnit selenium = new TestUnit();
            //selenium.Selenium();

            return View();
        }

        public void teste()
        {
            //** Chamando o teste de integração.
            TestUnit selenium = new TestUnit();
            selenium.Selenium();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}