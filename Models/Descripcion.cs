using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace AMARILLO.Models
{

    [Table("Descripcion")]
    public class Descripcion
    {
         [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int id { get; set; }


        [Column("Nombre Producto")]
        public string nombreproducto { get; set; }


        [Column("Descripcion")]
        public string descripcion { get; set; }



        [Column("Adicional")]
        public string adicional { get; set; }
        

        [NotMapped]
        public string Respuesta { get; set; }
    }
}