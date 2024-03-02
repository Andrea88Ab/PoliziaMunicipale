using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PoliziaMunicipale.Models;
using System.Collections.Generic;

namespace PoliziaMunicipale.Controllers
{
    public class TrasgressoreController : Controller
    {
        private readonly IConfiguration _configuration;

        public TrasgressoreController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: Trasgressore
        public ActionResult Create()
        {
            ViewBag.AllTrasgressori = DB.getAllTrasgressori(_configuration);
            return View();
        }

        public ActionResult List()
        {
            ViewBag.AllTrasgressori = DB.getAllTrasgressori(_configuration);
            return View();
        }

        [HttpPost]
        public ActionResult Create(Trasgressore t)
        {
            if (ModelState.IsValid)
            {
                DB.AggiungiTrasgressore(_configuration, t.Surname, t.Name, t.Address, t.City, t.CAP, t.CF);
                return RedirectToAction("List", "Trasgressore");
            }
            else
            {
                ViewBag.AllTrasgressori = DB.getAllTrasgressori(_configuration);
                return View(t);
            }
        }

        public ActionResult Edit(int id)
        {
            Trasgressore t = DB.getTrasgressoreById(_configuration, id);
            return View(t);
        }

        [HttpPost]
        public ActionResult Edit(Trasgressore t)
        {
            if (ModelState.IsValid)
            {
                DB.UpdateTrasgressore(_configuration, t.Id, t.Surname, t.Name, t.Address, t.City, t.CAP, t.CF);
                return RedirectToAction("List", "Trasgressore");
            }
            else return View(t);
        }

        public ActionResult Delete(int id)
        {
            DB.RemoveTrasgressore(_configuration, id);
            return RedirectToAction("List", "Trasgressore");
        }
    }
}
