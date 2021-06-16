using System;
using System.Collections.Generic;
using System.Text;
using AMARILLO.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AMARILLO.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
       
       
        public DbSet<AMARILLO.Models.Producto> Producto { get; set; }
        public DbSet<TipoProducto> TipoProducto { get; set; }
        public DbSet<Descripcion> Descripcion { get; set; }
        public DbSet<Compra> Compra { get; set; }
        public DbSet<DetalleCompra> DetalleCompra { get; set; }
        public DbSet<AMARILLO.Models.Contacto> Contacto {get; set;}
    }
}
