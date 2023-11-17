using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoCoffi.Models
{
    [Table("t_pedido")]
    public class Pedido
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id {get; set;}

        public String UserID{ get; set; }

        public Decimal Total { get; set; }

        public Pago pago { get; set; }

        public String Status { get; set; }
    }
}