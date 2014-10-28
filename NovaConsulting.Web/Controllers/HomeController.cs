using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.SqlServer.Server;
using NovaConsulting.Web.Models;
using NovaConsulting.Web.Util;

namespace NovaConsulting.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string ContactForm(Contato contato)
        {
            try
            {
                var email = new SendMail();
                email.EnviarEmail(contato);
                email.EnviaEmailResponsavel(contato);
               

                return "info";
            }
            catch (Exception ex)
            {
                return "erro";
            }
        }
    }
}