using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
using AMARILLO.Data;
using AMARILLO.Models;
namespace AMARILLO.Controllers
{
    public class DescripcionController:Controller
    {
        
        private readonly ILogger<DescripcionController> _logger;
         private readonly ApplicationDbContext _context;
         

        public DescripcionController(ILogger<DescripcionController> logger,
        ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
           
        }


        
        [HttpPost]
        public IActionResult Create(Descripcion descripcion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(descripcion);
                _context.SaveChanges();
                
            }

            return View("DescripcionConfirmacion");
        }


        public IActionResult Index()
        {
            var lisdecripcion=_context.Descripcion.ToList();
            return View(lisdecripcion);
        }

        public IActionResult Invitado()
        {
            var lisdecripcion=_context.Descripcion.ToList();
            return View(lisdecripcion);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var descripcion = await _context.Descripcion.FindAsync(id);
            if (descripcion == null)
            {
                return NotFound();
            }
            return View(descripcion);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nombreproducto,descripcion,adicional")] Descripcion descripcion)
        {
            if (id != descripcion.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(descripcion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                    
                }
                return RedirectToAction(nameof(Index));
            }
            return View(descripcion);
        }



        public IActionResult Delete(int? id)
        {
            var plaga = _context.Descripcion.Find(id);
            _context.Descripcion.Remove(plaga);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }



        public async Task<IActionResult> Detalle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Descripcion descripcion = await _context.Descripcion.FindAsync(id);
            if (descripcion == null)
            {
                return NotFound();
            }
            return View("Detalle",descripcion);
        }


        public async Task<IActionResult> DetalleInvitado(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Descripcion descripcion = await _context.Descripcion.FindAsync(id);
            if (descripcion == null)
            {
                return NotFound();
            }
            return View("DetalleInvitado",descripcion);
        }



      public IActionResult Formulario()
     {
           return View();
        }
        

    }
}