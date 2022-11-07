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
    }
}