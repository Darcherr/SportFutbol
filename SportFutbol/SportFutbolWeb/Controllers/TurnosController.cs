﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportFutbolWeb.Domain.Entities;
using SportFutbolWeb.Infrastructure;

namespace SportFutbolWeb.Controllers
{
    public class TurnosController : Controller
    {
        private readonly SportFutbolContext _context;

        public TurnosController(SportFutbolContext context)
        {
            _context = context;
        }

        // GET: Turnos
        public async Task<IActionResult> Index()
        {
            var sportFutbolContext = _context.Turnos.Include(t => t.Cancha).Include(t => t.Tarifa);
            return View(await sportFutbolContext.ToListAsync());
        }

        // GET: Turnos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Turnos == null)
            {
                return NotFound();
            }

            var turno = await _context.Turnos
                .Include(t => t.Cancha)
                .Include(t => t.Tarifa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (turno == null)
            {
                return NotFound();
            }

            return View(turno);
        }

        // GET: Turnos/Create
        public IActionResult Create()
        {
            ViewData["IdCancha"] = new SelectList(_context.Canchas, "Id", "Id");
            ViewData["IdTarifa"] = new SelectList(_context.Tarifas, "Id", "Id");
            return View();
        }

        // POST: Turnos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion,IdCancha,FechaTurno,NombreCliente,IdTarifa")] Turno turno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(turno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCancha"] = new SelectList(_context.Canchas, "Id", "Id", turno.IdCancha);
            ViewData["IdTarifa"] = new SelectList(_context.Tarifas, "Id", "Id", turno.IdTarifa);
            return View(turno);
        }

        // GET: Turnos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Turnos == null)
            {
                return NotFound();
            }

            var turno = await _context.Turnos.FindAsync(id);
            if (turno == null)
            {
                return NotFound();
            }
            ViewData["IdCancha"] = new SelectList(_context.Canchas, "Id", "Id", turno.IdCancha);
            ViewData["IdTarifa"] = new SelectList(_context.Tarifas, "Id", "Id", turno.IdTarifa);
            return View(turno);
        }

        // POST: Turnos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,IdCancha,FechaTurno,NombreCliente,IdTarifa")] Turno turno)
        {
            if (id != turno.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(turno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TurnoExists(turno.Id))
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
            ViewData["IdCancha"] = new SelectList(_context.Canchas, "Id", "Id", turno.IdCancha);
            ViewData["IdTarifa"] = new SelectList(_context.Tarifas, "Id", "Id", turno.IdTarifa);
            return View(turno);
        }

        // GET: Turnos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Turnos == null)
            {
                return NotFound();
            }

            var turno = await _context.Turnos
                .Include(t => t.Cancha)
                .Include(t => t.Tarifa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (turno == null)
            {
                return NotFound();
            }

            return View(turno);
        }

        // POST: Turnos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Turnos == null)
            {
                return Problem("Entity set 'SportFutbolContext.Turnos'  is null.");
            }
            var turno = await _context.Turnos.FindAsync(id);
            if (turno != null)
            {
                _context.Turnos.Remove(turno);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TurnoExists(int id)
        {
          return (_context.Turnos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
