using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BagLib;
using BagLib.Models;

namespace BagMVC.Controllers
{
    public class MarketsController : Controller
    {
        private readonly BagContext _context;

        public MarketsController(BagContext context)
        {
            _context = context;
        }

        // GET: Markets
        public async Task<IActionResult> Index()
        {
            return View(await _context.Market.ToListAsync());
        }

        // GET: Markets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var market = await _context.Market
                .FirstOrDefaultAsync(m => m.MarketId == id);
            if (market == null)
            {
                return NotFound();
            }

            return View(market);
        }

        // GET: Markets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Markets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MarketId,Name,Description,CountryId,TimeZone")] Market market)
        {
            if (ModelState.IsValid)
            {
                _context.Add(market);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(market);
        }

        // GET: Markets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var market = await _context.Market.FindAsync(id);
            if (market == null)
            {
                return NotFound();
            }
            return View(market);
        }

        // POST: Markets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MarketId,Name,Description,CountryId,TimeZone")] Market market)
        {
            if (id != market.MarketId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(market);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarketExists(market.MarketId))
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
            return View(market);
        }

        // GET: Markets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var market = await _context.Market
                .FirstOrDefaultAsync(m => m.MarketId == id);
            if (market == null)
            {
                return NotFound();
            }

            return View(market);
        }

        // POST: Markets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var market = await _context.Market.FindAsync(id);
            _context.Market.Remove(market);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarketExists(int id)
        {
            return _context.Market.Any(e => e.MarketId == id);
        }
    }
}
