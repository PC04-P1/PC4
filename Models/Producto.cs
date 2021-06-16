using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AMARILLO.Models
{

    [Table("Producto")]
    public class Producto
    {
         [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        [Key]
        public int ID { get; set; }

        [Display(Name="Nombre")]
        [Required(ErrorMessage = "Por favor, ingrese el nombre del producto")]
        [Column("Nombre")]
        public string Nombre { get; set; }

        [Display(Name="URL de imagen")]
        [Required(ErrorMessage = "Por favor, ingrese la imagen del producto")]
        [Column("ImagenURL")]
        public string ImagenURL { get; set; }
        // public byte[] Imagen { get; set; }

        // [NotMapped]
        // public String ImageData { get; set; }

        [Display(Name="Precio")]
        [Required(ErrorMessage = "Por favor, ingrese el precio del producto")]
       
        public decimal Precio { get; set; }


        [Display(Name="Stock")]
        [Required(ErrorMessage = "Por favor, ingrese stock")]
        [Column("Stock")]
        public int Stock { get; set; }  

        [Display(Name="Accesorios")]
        [Column("Accesorios")]
        public string Accesorios { get; set; }

                [Display(Name="Elejir")]
        [Column("Elejir")]
        public string Elejir { get; set; }



        [Display(Name="Tips")]
        [Column("Tips")]
        public string Tips { get; set; }

        [Column("Deshabilitado")]
        public bool Deshabilitado { get; set; }


        [Display(Name="Tipo Producto")]
        [ForeignKey("IDTipoProdcuto")]
         public string TipoProducto { get; set; }
         public int IDTipoProducto { get; set; }

         [NotMapped]
         public string Respuesta { get; set; }
    }
}