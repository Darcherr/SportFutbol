using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportFutbolWeb.Domain.Entities;
using SportFutbolWeb.Infrastructure;
using SportFutbolWeb.ViewModels;

namespace SportFutbolWeb.Controllers
{
    public class CanchasController : Controller
    {
        private readonly SportFutbolContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CanchasController(SportFutbolContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Canchas
        public async Task<IActionResult> Index()
        {
            var sportFutbolContext = _context.Canchas.Include(c => c.TipoCancha);
            return View(await sportFutbolContext.ToListAsync());
        }

        // GET: Canchas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Canchas == null)
            {
                return NotFound();
            }

            var cancha = await _context.Canchas
                .Include(c => c.TipoCancha)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cancha == null)
            {
                return NotFound();
            }

            return View(cancha);
        }

        // GET: Canchas/Create
        public IActionResult Create()
        {
            ViewData["TipoRefId"] = new SelectList(_context.TipoCanchas, "Id", "Descripcion");
            return View();
        }

        // POST: Canchas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CanchaViewModel model)
        {

            string uniqueFileName = UploadedFile(model);
            if (ModelState.IsValid)
            {
                Cancha cancha = new Cancha()
                {
                    ImagenCancha = uniqueFileName,
                    TipoRefId = model.TipoRefId,
                    Descripcion = model.Descripcion,

                };
                _context.Add(cancha);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoRefId"] = new SelectList(_context.TipoCanchas, "Id", "Descripcion", model.TipoRefId);
            return View(model);
        }

        // GET: Canchas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Canchas == null)
            {
                return NotFound();
            }

            var cancha = await _context.Canchas.FindAsync(id);
            if (cancha == null)
            {
                return NotFound();
            }
            ViewData["TipoRefId"] = new SelectList(_context.TipoCanchas, "Id", "Descripcion", cancha.TipoRefId);
            return View(cancha);
        }

        // POST: Canchas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,TipoRefId,ImagenCancha")] Cancha cancha)
        {
            if (id != cancha.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cancha);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CanchaExists(cancha.Id))
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
            ViewData["TipoRefId"] = new SelectList(_context.TipoCanchas, "Id", "Descripcion", cancha.TipoRefId);
            return View(cancha);
        }

        // GET: Canchas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Canchas == null)
            {
                return NotFound();
            }

            var cancha = await _context.Canchas
                .Include(c => c.TipoCancha)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cancha == null)
            {
                return NotFound();
            }

            return View(cancha);
        }

        // POST: Canchas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Canchas == null)
            {
                return Problem("Entity set 'SportFutbolContext.Canchas'  is null.");
            }
            var cancha = await _context.Canchas.FindAsync(id);
            if (cancha != null)
            {
                _context.Canchas.Remove(cancha);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CanchaExists(int id)
        {
            return (_context.Canchas?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private string UploadedFile(CanchaViewModel model)
        {
            string uniqueFileName = null;

            if (model.Imagen != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Imagen.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Imagen.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}
