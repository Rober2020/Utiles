using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BeerController : Controller
    {
        public IActionResult Create()
        {
            ViewBag.Message = TempData["Message"];
            return View();
        }

        [HttpPost]
        public IActionResult Create(Beer beer)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", beer);
            }
            //guardar en la bd
            TempData["Messa"] = "Cerveza guardada";
            return Redirect("Create");
        }
    }
}
