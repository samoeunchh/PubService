using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoiService.Data;
using MoiService.Models;

namespace MoiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinceApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProvinceApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ProvinceApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Province>>> GetProvince()
        {
            return await _context.Province.ToListAsync();
        }

        // GET: api/ProvinceApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Province>> GetProvince(Guid id)
        {
            var province = await _context.Province.FindAsync(id);

            if (province == null)
            {
                return NotFound();
            }

            return province;
        }

        // PUT: api/ProvinceApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProvince(Guid id, Province province)
        {
            if (id != province.ProvinceId)
            {
                return BadRequest();
            }

            _context.Entry(province).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProvinceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ProvinceApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Province>> PostProvince(Province province)
        {
            _context.Province.Add(province);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProvince", new { id = province.ProvinceId }, province);
        }

        // DELETE: api/ProvinceApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProvince(Guid id)
        {
            var province = await _context.Province.FindAsync(id);
            if (province == null)
            {
                return NotFound();
            }

            _context.Province.Remove(province);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProvinceExists(Guid id)
        {
            return _context.Province.Any(e => e.ProvinceId == id);
        }
    }
}
