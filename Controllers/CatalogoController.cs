using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProyectoCoffi.Controllers
{
    public class CatalogoController : Controller
    {
        public IActionResult Cata()
        {
            return View("Cata");
        }
    }
}