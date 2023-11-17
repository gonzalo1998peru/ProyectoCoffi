using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProyectoCoffi.Models;
using ProyectoCoffi.Data;

namespace ProyectoCoffi.Controllers
{
    public class PersonaController : Controller
    {
        private readonly ILogger<PersonaController> _logger;
        private readonly ApplicationDbContext _context;

        public PersonaController(ILogger<PersonaController> logger,
        ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Persona objPersona)
        {
            _context.Add(objPersona);
            _context.SaveChanges();
            ViewData["Message"] = string.Concat("Estimado " , objPersona.nombres, " te estaremos contactando pronto.");
            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}