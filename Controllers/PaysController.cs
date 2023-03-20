﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROJET_C.Data;
using PROJET_C.Models;

namespace PROJET_C.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaysController : ControllerBase
    {
        private readonly PROJET_CContext _context;

        public PaysController(PROJET_CContext context)
        {
            _context = context;
        }

        // GET: api/Pays
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pay>>> GetPay()
        {
            return await _context.Pay.Include("Populations").ToListAsync();
        }

        // GET: api/Pays/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pay>> GetPay(int id)
        {
            var pay = await _context.Pay.FindAsync(id);

            if (pay == null)
            {
                return NotFound();
            }

            return pay;
        }

        // PUT: api/Pays/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPay(int id, Pay pay)
        {
            if (id != pay.Id)
            {
                return BadRequest();
            }

            _context.Entry(pay).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PayExists(id))
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

        // POST: api/Pays
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pay>> PostPay(Pay pay)
        {
            _context.Pay.Add(pay);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPay", new { id = pay.Id }, pay);
        }

        // DELETE: api/Pays/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePay(int id)
        {
            var pay = await _context.Pay.FindAsync(id);
            if (pay == null)
            {
                return NotFound();
            }

            _context.Pay.Remove(pay);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PayExists(int id)
        {
            return _context.Pay.Any(e => e.Id == id);
        }
    }
}
