using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoiService.Data;
using MoiService.Models;
namespace MoiService.Controllers;

[Authorize]
public class ProvinceController : Controller
{
    private readonly ApplicationDbContext _context;

    public ProvinceController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Province
    public async Task<IActionResult> Index()
    {
          return View(await _context.Province.ToListAsync());
    }

    // GET: Province/Details/5
    public async Task<IActionResult> Details(Guid? id)
    {
        if (id == null || _context.Province == null)
        {
            return NotFound();
        }

        var province = await _context.Province
            .FirstOrDefaultAsync(m => m.ProvinceId == id);
        if (province == null)
        {
            return NotFound();
        }

        return View(province);
    }

    // GET: Province/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Province/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ProvinceId,NameKh,NameEn,ContactNumer")] Province province)
    {
        if (ModelState.IsValid)
        {
            province.ProvinceId = Guid.NewGuid();
            _context.Add(province);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(province);
    }

    // GET: Province/Edit/5
    public async Task<IActionResult> Edit(Guid? id)
    {
        if (id == null || _context.Province == null)
        {
            return NotFound();
        }

        var province = await _context.Province.FindAsync(id);
        if (province == null)
        {
            return NotFound();
        }
        return View(province);
    }

    // POST: Province/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, Province province)
    {
        if (id != province.ProvinceId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(province);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProvinceExists(province.ProvinceId))
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
        return View(province);
    }

    // GET: Province/Delete/5
    public async Task<IActionResult> Delete(Guid? id)
    {
        if (id == null || _context.Province == null)
        {
            return NotFound();
        }

        var province = await _context.Province
            .FirstOrDefaultAsync(m => m.ProvinceId == id);
        if (province == null)
        {
            return NotFound();
        }

        return View(province);
    }

    // POST: Province/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        if (_context.Province == null)
        {
            return Problem("Entity set 'ApplicationDbContext.Province'  is null.");
        }
        var province = await _context.Province.FindAsync(id);
        if (province != null)
        {
            _context.Province.Remove(province);
        }
        
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ProvinceExists(Guid id)
    {
      return _context.Province.Any(e => e.ProvinceId == id);
    }
}
