using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoCoffi.Models{
    [Table("t_producto")]
    public class Producto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Descripcion { get; set; }
        public Decimal Precio { get; set; }
        public Decimal PorcentajeDescuento { get; set; }
        public string? ImageName { get; set; }
        public string? Status { get; set; }
        public int Cantidad { get; set; } // Agrega la propiedad Cantidad
    }
}