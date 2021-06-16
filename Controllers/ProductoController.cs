using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using AMARILLO.Data;
using AMARILLO.Models;
using System.Dynamic;
using System.Collections.Generic;

namespace AMARILLO.Controllers
{
    public class ProductoController:Controller
    {
        
         private readonly ILogger<ProductoController> _logger;
        private readonly ApplicationDbContext _context; 
        private IEnumerable<Producto> _productos;
        private List<TipoProducto> ListaTipos;

        
        public ProductoController(ILogger<ProductoController> logger,
            ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
           
            ListaTipos = _context.TipoProducto.ToList();
        }            
        
   

        public async Task<IActionResult> Index(int BuscarProducto)
        {
            _productos = _context.Producto.ToList();
            dynamic model= new ExpandoObject();
            model.TipoProducto = ListaTipos;

            var producto = from m in _productos
            select m;

            if(BuscarProducto!=0){
            _productos = _productos.Where(s => s.IDTipoProducto==BuscarProducto);
            }
            model.Producto = _productos;
            return View(await Task.FromResult(model));
        }

        public IActionResult Detalle(int? ID)
        {
            _productos = _context.Producto.ToList();
            if (ID == null)
            {
                return NotFound();
            }
            Producto producto = new Producto();
            foreach(var i in _productos)
            {
                if (i.ID==ID)
                producto = i;
            }
            return View(producto);
        }

        public IActionResult Formulario()
        {
            var ListaTipo = _context.TipoProducto.ToList();
            var producto = new Producto();
            dynamic model = new ExpandoObject();
            model.producto = producto;
            model.TipoProducto = ListaTipo;
            return View(model);
        }

        [HttpPost]
        public IActionResult Formulario(Producto producto)
        {
            producto.IDTipoProducto = int.Parse(Request.Form["IDTipoProducto"]);
            if (ModelState.IsValid)
            {
                _context.Add(producto);
                _context.SaveChanges();
                producto.Respuesta="Producto Creado";
                return RedirectToAction("Index");
            }
            else{
                producto.Respuesta="No se pudo añadir";
                return View(producto);
            }         
        }        
        
        [HttpPost]
        public IActionResult Cargar(Producto objProducto){
            if (ModelState.IsValid)
            {
                _context.Add(objProducto);
                _context.SaveChanges();
                objProducto.Respuesta = "Producto cargado a la tienda";
                return View(objProducto);
            }else
            {
                objProducto.Respuesta = "Error, no se pudo cargar a la tienda";
                return View(objProducto);
            }
            
        }

       
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var _producto = await _context.Producto.FindAsync(id);
            if (_producto == null)
            {
                return NotFound();
            }

            ViewBag.TipoProducto = ListaTipos;

            return View(_producto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nombre,IDTipoProducto,ImagenURL,Precio,Stock,Elejir, Accesorios, Tips")] Producto _producto)
        {
            if (id != _producto.ID)
            {
                 return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _producto.IDTipoProducto = int.Parse(Request.Form["IDTipoProducto"]);
                    _context.Update(_producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                    
                }
                return RedirectToAction(nameof(Index));
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            dynamic model = new ExpandoObject();
            model.TipoProducto=ListaTipos;
            model.producto=_producto;
            return View(model);
        }
        
        public IActionResult Delete(int? id)
        {
            var producto = _context.Producto.Find(id);
            _context.Producto.Remove(producto);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

         public IActionResult Habilitar(int? id)
        {
            var producto = _context.Producto.Find(id);
            //algo hice mal
            // planta.Deshabilitado = true ? false : true;

            if(producto.Deshabilitado==true){
                producto.Deshabilitado=false;
            }
            else{
            producto.Deshabilitado=true;}

            _context.Producto.Update(producto);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        
    }
}