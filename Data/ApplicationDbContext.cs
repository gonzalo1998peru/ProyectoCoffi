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

}
