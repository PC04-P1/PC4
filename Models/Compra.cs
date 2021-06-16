using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMARILLO.Models
{
    public class Compra
    {
                [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int ID { get; set; }

        [Column("Fecha")]
        public DateTime Fecha { get; set; }

        [Display(Name="Total")]

        [Column("Total")]
        public decimal Total { get; set; }


        [Display(Name="Producto")]
        [Column("Producto")]
        public string Producto { get; set; }

        [Display(Name="Correo")]
        [Column("Correo")]
        public string Usuario { get; set; }

        [Display(Name="Tipo del Producto")]
        [ForeignKey("ProductoID")]
        public int ProductoID { get; set; }

        [Display(Name="Cantidad")]
        [Column("Cantidad")]
        public int Cantidad { get; set; }

        [Display(Name="Precio Unitario")]

        [Column("PrecioUnit")]
        public decimal Preciounit { get; set; }
        
    }
}