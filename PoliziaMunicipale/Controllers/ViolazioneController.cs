using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PoliziaMunicipale.Models;
using System.Collections.Generic;

namespace PoliziaMunicipale.Controllers
{
    public class ViolazioneController : Controller
    {
        private readonly IConfiguration _configuration;

        public ViolazioneController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: Violazione
        public ActionResult Create()
        {
            ViewBag.AllViolazioni = DB.getAllViolazioni(_configuration); 
            return View();
        }

        [HttpPost]
        public ActionResult Create(Violazione v)
        {
            if (ModelState.IsValid)
            {
                DB.AggiungiViolazione(_configuration, v.Description); 
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.AllViolazioni = DB.getAllViolazioni(_configuration); 
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            Violazione v = DB.getViolazioneById(_configuration, id); 
            return View(v);
        }

        [HttpPost]
        public ActionResult Edit(Violazione v)
        {
            if (ModelState.IsValid)
            {
                DB.UpdateViolazione(_configuration, v.Id, v.Description); 
                return RedirectToAction("Index", "Home");
            }
            else return View(v);
        }

        public ActionResult Delete(int id)
        {
            DB.RemoveViolazione(_configuration, id); 
            return RedirectToAction("Index", "Home");
        }
    }
}
