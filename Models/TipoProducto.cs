using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using AMARILLO.Models;
namespace AMARILLO.Models
{
    public class TipoProducto
    {
         [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int ID { get; set; }

        [Column("Tipo")]
        public string Nombre { get; set; }

        [Column("Deshabilitado")]
        public bool Deshabilitado { get; set; }

        // [ForeignKey("IdTipo")]
        public ICollection<Producto> Productos { get; set; }

        public TipoProducto()
        {
            Productos = new List<Producto>();
        }
    }
}