using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AMARILLO.Data;
using AMARILLO.Models;
namespace AMARILLO.Controllers
{
    public class CompraController:Controller
    {
        
         private readonly ILogger<ProductoController> _logger;
        private readonly ApplicationDbContext _context; 
        public CompraController(ILogger<ProductoController> logger,
            ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        } 
        [Authorize]
        public IActionResult Index()
        {
            var Ordenes=_context.Compra.Where(x => x.Usuario != null).ToList();
            return View(Ordenes);
        }
        
        public IActionResult AddItem(int? id)
        {
            var producto = _context.Producto.Find(id);
            var orderDetail = new Compra();
            orderDetail.ProductoID = producto.ID;
            orderDetail.Preciounit = producto.Precio;
            orderDetail.Cantidad = 1;
            orderDetail.Usuario = User.Identity.Name;
            orderDetail.Fecha = DateTime.Now;
            orderDetail.Total = orderDetail.Cantidad * orderDetail.Preciounit;
            orderDetail.Producto = producto.Nombre;
            _context.Compra.Add(orderDetail);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        
    }
}