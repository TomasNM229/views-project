using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using views_project.Models;

namespace views_project.Controllers
{
    public class PublicoController : Controller
    {
        private readonly views_projectContext _context;

        public PublicoController(views_projectContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Publico.ToListAsync());
        }

        public async Task<IActionResult> Details(int ? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            
            var publico = await _context.Publico.FirstOrDefaultAsync(p => p.IDPublico == id);

            if(publico == null)
            {
                return NotFound();
            }
            return View(publico);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // Validar nuestro metodo que ha sido ejecutado mediante el formulario y no desde la URL, previene de ataques
        public async Task<IActionResult> Create([Bind("IDPublico, Nombre, Apellido, Edad, Correo, Telefono")]Publico publico)
        {
            if(ModelState.IsValid)
            {
                _context.Add(publico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}