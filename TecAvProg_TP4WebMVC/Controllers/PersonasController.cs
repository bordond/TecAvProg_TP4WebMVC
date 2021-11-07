using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TecAvProg_TP4WebMVC.Controllers
{
    public class PersonasController : Controller
    {
        // GET: Personas
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Alta()
        {
            return View(new Negocio.Persona());
        }
        [HttpPost]
        public ActionResult Crear(Negocio.Persona persona)
        {
            persona.Grabar();
            return RedirectToAction("Alta");
        }
    }
}
