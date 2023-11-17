using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Dynamic;
using ProyectoCoffi.Data;
using ProyectoCoffi.Models;

namespace ProyectoCoffi.Controllers.UI
{
    public class CarritoController : Controller
    {
        private readonly ILogger<CarritoController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        
        public CarritoController(ILogger<CarritoController> logger,
            ApplicationDbContext context,
            UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {   var userIDSession = _userManager.GetUserName(User);

            //select proforma pr, product p WHERE join ... And pr.user = usuarion sesionado

            var items = from o in _context.DataProforma select o;
            items = items.Include(p => p.Producto).
                Where(w => w.UserID.Equals(userIDSession) &&
                    w.Status.Equals("PENDIENTE")
                    );

            var itemsCarrito = items.ToList();
            //Fila1 1234, Shampo; Precio, Cantidad
            //Fila2 12345, Shampo3; Precio, Cantidad
            var total = itemsCarrito.Sum(c => c.Cantidad * c.Precio);
            
            //MEMORIA
            dynamic model = new ExpandoObject();
            model.montoTotal = total;
            model.elementosCarrito = itemsCarrito;
            return View(model);
        }

        public async Task<IActionResult> Edit(int? id)
        {
          if (id == null)
    {
        return NotFound();
    }

    var itemproforma = await _context.DataProforma.Include(p => p.Producto).FirstOrDefaultAsync(p => p.Id == id);
    if (itemproforma == null)
    {
        return NotFound();
    }

    return View(itemproforma);
        }

        


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(int id, [Bind("Id,Cantidad,Precio,UserID")] Proforma itemcarrito)
        {
            if (id != itemcarrito.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemcarrito);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.DataProforma.Any(e => e.Id == id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(itemcarrito);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemcarrito = await _context.DataProforma.FindAsync(id);
            _context.DataProforma.Remove(itemcarrito);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        } 

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}