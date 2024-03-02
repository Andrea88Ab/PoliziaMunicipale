using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using PoliziaMunicipale.Models;
using System.Collections.Generic;

namespace PoliziaMunicipale.Controllers
{
    public class VerbaleController : Controller
    {
        private readonly IConfiguration _configuration;

        public VerbaleController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ActionResult Create()
        {
            ViewBag.ListaTrasgressori = new SelectList(DB.getAllTrasgressori(_configuration), "Id", "FullName");
            ViewBag.ListaViolazioni = new SelectList(DB.getAllViolazioni(_configuration), "Id", "Description");
            ViewBag.ListaVerbali = DB.getAllVerbali(_configuration);
            return View();
        }

        [HttpPost]
        public ActionResult Create(Verbale verbale)
        {
            if (ModelState.IsValid)
            {
                DB.AggiungiVerbale(_configuration, verbale.DataViolazione, verbale.IndirizzoViolazione, verbale.Agente, verbale.DataVerbale, verbale.Importo, verbale.PuntiTolti, verbale.IdTrasgressore, verbale.IdViolazione);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ListaTrasgressori = new SelectList(DB.getAllTrasgressori(_configuration), "Id", "FullName", verbale.IdTrasgressore);
                ViewBag.ListaViolazioni = new SelectList(DB.getAllViolazioni(_configuration), "Id", "Description", verbale.IdViolazione);
                ViewBag.ListaVerbali = DB.getAllVerbali(_configuration);
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            ViewBag.ListaTrasgressori = new SelectList(DB.getAllTrasgressori(_configuration), "Id", "FullName");
            ViewBag.ListaViolazioni = new SelectList(DB.getAllViolazioni(_configuration), "Id", "Description");
            Verbale verbale = DB.getVerbaleById(_configuration, id);
            return View(verbale);
        }

        [HttpPost]
        public ActionResult Edit(Verbale verbale)
        {
            if (ModelState.IsValid)
            {
                DB.UpdateVerbale(_configuration, verbale.Id, verbale.DataViolazione, verbale.IndirizzoViolazione, verbale.Agente, verbale.DataVerbale, verbale.Importo, verbale.PuntiTolti, verbale.IdTrasgressore, verbale.IdViolazione);
                return RedirectToAction("Index", "Home");
            }
            else return View(verbale);
        }

        public ActionResult Remove(int id)
        {
            DB.RemoveVerbale(_configuration, id);
            DB.DeleteAnagraficaAndRelatedVerbale(_configuration, id);
            return RedirectToAction("Create", "Verbale");
        }
    }
}
