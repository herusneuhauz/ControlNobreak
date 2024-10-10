using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ControlNobreak.Data;
using ControlNobreak.Models;

namespace ControlNobreak.Controllers
{
    public class NobreaksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NobreaksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Ação para listar os Nobreaks (Index)
        public async Task<IActionResult> Index()
        {
            try
            {
                var ListNobreak = await _context.Nobreaks
                    .ToListAsync();

                ViewBag.contagemRegistro = _context.Nobreaks.Count();
                ViewBag.somaNobreaks = _context.Nobreaks.Sum(x => x.Quantidade);

                return View(ListNobreak);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        // Ação para criar (GET)
        public IActionResult Create()
        {
            return View();
        }

        // Ação para criar (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Nobreak nobreak)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nobreak);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nobreak);
        }

        // Ação para editar (GET)
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nobreak = await _context.Nobreaks.FindAsync(id);
            if (nobreak == null)
            {
                return NotFound();
            }
            return View(nobreak);
        }

        // Ação para editar (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Marca,Modelo,Potencia,DataManutencao,Serie,Quantidade")] Nobreak nobreak)
        {
            if (id != nobreak.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nobreak);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NobreakExists(nobreak.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(nobreak);
        }

        // Ação para excluir (GET)
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nobreak = await _context.Nobreaks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nobreak == null)
            {
                return NotFound();
            }

            return View(nobreak);
        }

        // Ação para confirmar exclusão (POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nobreak = await _context.Nobreaks.FindAsync(id);

            if (nobreak == null)
            {
                return NotFound();
            }

            _context.Nobreaks.Remove(nobreak);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NobreakExists(int id)
        {
            return _context.Nobreaks.Any(e => e.Id == id);
        }
    }
}
