using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AMARILLO.Models
{
    public class DetalleCompra
    {
         [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int ID { get; set; }  

        [Display(Name="Tipo Producto")]
        [ForeignKey("OrdenID")]
        public int OrdenID { get; set; }

        [Display(Name="Tipo Producto")]
        [ForeignKey("ProductoID")]
        public int ProductoID { get; set; }

        [Column("Cantidad")]
        public int Cantidad { get; set; }

        [Column("PrecioUnit")]
        public double Preciounit { get; set; }

        [NotMapped]
        public double SubTotal { get; set; }
    }
}