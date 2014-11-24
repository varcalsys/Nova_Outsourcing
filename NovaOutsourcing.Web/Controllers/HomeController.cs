using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NovaOutsourcing.Domain.Entities;
using NovaOutsourcing.Domain.Interfaces.Services;
using NovaOutsourcing.Domain.Services;
using NovaOutsourcing.Web.Models;

namespace NovaOutsourcing.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly INewsletterService _newsletterService;
        private readonly IVisitanteService _visitanteService;

        public HomeController(INewsletterService newsletterService, IVisitanteService visitanteService)
        {
            _newsletterService = newsletterService;
            _visitanteService = visitanteService;
        }

        public ActionResult Index()
        {
            _visitanteService.Inserir(new Visitante());
            return Redirect("Index.html");
        }

        [HttpPost]
        public string Contato(Contato contato)
        {
            try
            {
                var email = new SendMail();
                email.EnviarEmail(contato);
                email.EnviaEmailResponsavel(contato);
                return "ok";
            }
            catch (Exception)
            {

                return "erro";
            }
            
        }

        [HttpPost]
        public string NewsLetter(string newsletter)
        {
            if (newsletter == "null" || newsletter == "")
            {
                return "erro";
            }

            try
            {
                var news = new Newsletter
                {
                    Email = newsletter,
                    Ativo = true
                };

                _newsletterService.Inserir(news);
                return "ok";
            }
            catch (Exception)
            {
                return "erro";
            }          
        }

        public ActionResult Contador()
        {
            ViewBag.Contador = _visitanteService.Contador();
            return View();
        }
    }
}