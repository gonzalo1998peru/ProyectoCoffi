using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoCoffi.Models; // Asegúrate de que los espacios de nombres coincidan con tu proyecto
using ProyectoCoffi.Data;
public class CarritoController : Controller
{
    private readonly ApplicationDbContext _context;

    public CarritoController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Acción para ver el contenido del carrito
    public IActionResult VerCarrito()
    {
        // Recupera los productos en el carrito desde la base de datos
        var productosEnCarrito = _context.DataProductos.ToList();

        // Calcula el total (puedes hacerlo según tus productos)
        var total = productosEnCarrito.Sum(p => p.Precio * p.Cantidad);

        // Crea una instancia de CarritoModel y asigna los productos y el total
        var carrito = new CarritoModel
        {
            Productos = productosEnCarrito,
            Total = total
        };

        // Pasa el carrito a la vista
        return View(carrito);
    }

    // Acción para agregar un producto al carrito
    [HttpPost]
    public IActionResult AgregarAlCarrito(int productoId, int cantidad)
    {
        // Recupera el producto desde la base de datos
        var producto = _context.DataProductos.FirstOrDefault(p => p.Id == productoId);

        if (producto == null)
        {
            // Producto no encontrado, maneja el error
            return NotFound();
        }

        // Actualiza la cantidad en el carrito
        producto.Cantidad += cantidad;

        // Guarda los cambios en la base de datos
        _context.SaveChanges();

        return RedirectToAction("VerCarrito");
    }

    // Otras acciones, como vaciar el carrito o pagar, pueden añadirse aquí
}
