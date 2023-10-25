using System.Collections.Generic;

public class CarritoModel
{
    public List<ProductoEnCarrito> Productos { get; set; }
    public decimal Total { get; set; }

    public CarritoModel()
    {
        Productos = new List<ProductoEnCarrito>();
        Total = 0;
    }
}

public class ProductoEnCarrito
{
    public int Id { get; set; } // Asegúrate de que tengas una propiedad Id
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
    public int Cantidad { get; set; }
    public string Foto { get; set; } // Asegúrate de que tengas una propiedad Foto
}
