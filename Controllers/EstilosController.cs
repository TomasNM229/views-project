using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        
        public IActionResult Index()
        {
            return View(_context.Estilos.ToList());
        }
        public IActionResult Edit(int ? id) //puede que lo recibamos en NULL por eso el "?"
        {
            if(id == null)
            {
                return NotFound();
            }
            var estilos = _context.Estilos.Find(id);

            if(estilos == null)
            {
                return NotFound();
            }

            return View(estilos);
        }
        [HttpPost] // método encargado del Post
        public IActionResult Edit(int id, [Bind("IDEspecialidad,Descripcion")] Estilos estilos)
        {
            if(id != estilos.IDEspecialidad)
            {
                return NotFound();
            }
            if(ModelState.IsValid)// si el modelo llegó sin errores?
            {
                _context.Update(estilos);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index)); //Nos dirige a la vista de Index
            }
            return View(estilos);
        }
        
        public IActionResult Delete(int ? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var estilos = _context.Estilos.FirstOrDefault(e => e.IDEspecialidad == id); //FirstOrDefault buscar la primera coincidencia y si no encuentra nada sería NULL

            if(estilos == null)
            {
                return NotFound();
            }

            return View(estilos);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var estilos = _context.Estilos.Find(id);
            _context.Estilos.Remove(estilos);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}