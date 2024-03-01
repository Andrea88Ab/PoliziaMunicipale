using Microsoft.AspNetCore.Mvc;
using PoliziaMunicipale.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace PoliziaMunicipale.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ActionResult Index()
        {
            ViewBag.VerbaliByT = DB.getCountVerbaliByTrasgressore(_configuration);
            ViewBag.PuntiByT = DB.getPuntiByTrasgressore(_configuration);
            ViewBag.Mag10Punti = DB.getTrasgressoriMag10Punti(_configuration);
            ViewBag.AmountMag400 = DB.getImportoMag400(_configuration);
            return View();
        }
    }
}
