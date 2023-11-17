using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProyectoCoffi.Models;


namespace ProyectoCoffi.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)            

        : base(options)
    {
    }   

    public DbSet<Persona> DataPersona { get; set; }

    public DbSet<Producto> DataProductos { get; set; }
    public DbSet<Proforma> DataCarrito { get; set; }

    public DbSet<ProyectoCoffi.Models.Pago> DataPago { get; set;}

    public DbSet<ProyectoCoffi.Models.Pedido> DataPedido { get; set;}
    public DbSet<DetallePedido> DataDetallePedido {get;set;}

    public DbSet<Proforma> DataProforma { get; set;}

    

}
