using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using views_project.Models;

namespace Controllers
{   
    public class EstilosController : Controller
    {
        private readonly views_projectContext _context;
        public EstilosController(views_projectContext context)
        {
            _context = context;
        }
        
        public async Task<IActionResult> Index() // la característica de "async" es para que pueda ser usado en simultaneo por varias personas
        {
            return View(await _context.Estilos.ToListAsync()); //ASYNC
        }
        public async Task<IActionResult> Edit(int ? id) //puede que lo recibamos en NULL por eso el "?"
        {
            if(id == null)
            {
                return NotFound();
            }
            var estilos = await _context.Estilos.FindAsync(id); //ASYNC

            if(estilos == null)
            {
                return NotFound();
            }

            return View(estilos);
        }
        [HttpPost] // método encargado del Post
        public async Task<IActionResult> Edit(int id, [Bind("IDEspecialidad,Descripcion")] Estilos estilos)
        {
            if(id != estilos.IDEspecialidad)
            {
                return NotFound();
            }
            if(ModelState.IsValid)// si el modelo llegó sin errores?
            {
                _context.Update(estilos);
                await _context.SaveChangesAsync(); //ASYNC

                return RedirectToAction(nameof(Index)); //Nos dirige a la vista de Index
            }
            return View(estilos);
        }
        
        public async Task<IActionResult> Delete(int ? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var estilos = await _context.Estilos.FirstOrDefaultAsync(e => e.IDEspecialidad == id); //FirstOrDefault buscar la primera coincidencia y si no encuentra nada sería NULL //ASYNC
            
            if(estilos == null)
            {
                return NotFound();
            }

            return View(estilos);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var estilos = await _context.Estilos.FindAsync(id); //ASYNC
            _context.Estilos.Remove(estilos);
            await _context.SaveChangesAsync(); //ASYNC

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("IDEspecialidad, Descripcion")]Estilos estilos)
        {
            if(ModelState.IsValid)
            {
                _context.Add(estilos);
                await _context.SaveChangesAsync(); //ASYNC
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}