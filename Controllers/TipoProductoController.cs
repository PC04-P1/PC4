using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AMARILLO.Data;
using AMARILLO.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Dynamic;
using Microsoft.EntityFrameworkCore;

namespace AMARILLO.Controllers
{
    public class TipoProductoController : Controller
    {
         private readonly ILogger<TipoProductoController> _logger;
        private readonly ApplicationDbContext _context;
        private IEnumerable<Producto> _productos;
        private List<TipoProducto> ListaTipos;


        public TipoProductoController(ILogger<TipoProductoController> logger,
        ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
            _productos = _context.Producto.ToList();
            ListaTipos = _context.TipoProducto.ToList();
        }

        public IActionResult Index()
        {
            var listTipo=_context.TipoProducto.Where(x => x.Nombre != null).ToList();
            return View(listTipo);
        }
        public async Task<IActionResult> ProductoAsync(int BuscarProducto)
        {
            dynamic modelo= new ExpandoObject();
            modelo.TipoProducto = ListaTipos;

            var producto = from m in _productos
            select m;

            if(BuscarProducto!=0){
            _productos = _productos.Where(s => s.IDTipoProducto==BuscarProducto);
            }
            modelo.Producto = _productos;
            return View(await Task.FromResult(modelo));
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TipoProducto tipo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipo);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipo = await _context.TipoProducto.FindAsync(id);
            if (tipo == null)
            {
                return NotFound();
            }
            return View(tipo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nombre")] TipoProducto tipo)
        {
            if (id != tipo.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                    
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tipo);
        }
        
        // public IActionResult Delete(int? id)
        // {
        //     var tipo = _context.TipoPlanta.Find(id);
        //     _context.TipoPlanta.Remove(tipo);
        //     _context.SaveChanges();
        //     return RedirectToAction(nameof(Index));
        // }
        public IActionResult Habilitar(int? id)
        {
            var tipo = _context.TipoProducto.Find(id);
            //algo hice mal
            // tipo.Deshabilitado = false ? true : false; 
            if(tipo.Deshabilitado==true){
                tipo.Deshabilitado=false;
            }
            else{
            tipo.Deshabilitado=true;}

            _context.TipoProducto.Update(tipo);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}