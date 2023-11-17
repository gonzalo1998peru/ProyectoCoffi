using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProyectoCoffi.Data;
using ProyectoCoffi.Models;
using Microsoft.AspNetCore.Identity;

namespace ProyectoCoffi.Controllers
{
    public class CatalogoController : Controller
    {
        private readonly ILogger<CatalogoController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        private readonly SignInManager<IdentityUser> _signInManager;

        public CatalogoController(ILogger<CatalogoController> logger,
            ApplicationDbContext context,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Cata()
        {
            var productos = from o in _context.DataProductos select o;
            return View(productos.ToList());
        }

        public async Task<IActionResult> Details(int? id){
            Producto? objProduct = await _context.DataProductos.FindAsync(id);
            if(objProduct == null){
                return NotFound();
            }
            return View(objProduct);
        }

        public async Task<IActionResult> Add(int? id){
            var userID = _userManager.GetUserName(User);
            if(userID == null){
                //no se ha logueado
                ViewData["Message"] = "Por favor debe loguearse antes de agregar un producto";
                List<Producto> productos = new List<Producto>();
                return  View("Cata",productos);
            }else{
                //ya esta logueado
                var producto = await _context.DataProductos.FindAsync(id);
                Proforma proforma = new Proforma();
                proforma.Producto = producto;
                proforma.Precio = producto.Precio; //precio del producto en ese momento
                proforma.Cantidad = 1;
                proforma.UserID = userID;
                    Console.WriteLine("ID="+id+" | ProductoId="+producto.Id+" | Precio="+producto.Precio);
                _context.Add(proforma);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Cata));
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}