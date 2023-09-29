using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace ProyectoCoffi.Models
{

        [Table("t_persona")]

    public class Persona
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]

        public int Id { get; set; }
        public string? nombres {get; set; }
        public string? apellidos {get; set; }
        public char? dni {get; set; }
        public string? direccion {get; set; }
        public string? celular {get; set; }
        

    }
}