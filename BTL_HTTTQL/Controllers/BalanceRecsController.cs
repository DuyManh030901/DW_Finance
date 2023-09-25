using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BTL_HTTTQL.Models;

namespace BTL_HTTTQL.Controllers
{
    public class BalanceRecsController : Controller
    {
        private readonly QltcktContext _context;

        public BalanceRecsController(QltcktContext context)
        {
            _context = context;
        }

        // GET: BalanceRecs
        public async Task<IActionResult> Index()
        {
            var qltcktContext = _context.BalanceRecs.Include(b => b.AccodeNavigation).Include(b => b.Bra);
            return View(await qltcktContext.ToListAsync());
        }

        // GET: BalanceRecs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BalanceRecs == null)
            {
                return NotFound();
            }

            var balanceRec = await _context.BalanceRecs
                .Include(b => b.AccodeNavigation)
                .Include(b => b.Bra)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (balanceRec == null)
            {
                return NotFound();
            }

            return View(balanceRec);
        }

        // GET: BalanceRecs/Create
        public IActionResult Create()
        {
            ViewData["Accode"] = new SelectList(_context.Accounts, "Acid", "Acid");
            ViewData["BraId"] = new SelectList(_context.Branches, "BraId", "BraId");
            return View();
        }

        // POST: BalanceRecs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Content,Amount,Term,BraId,Accode,Accr,Acdr")] BalanceRec balanceRec)
        {
            if (ModelState.IsValid)
            {
                _context.Add(balanceRec);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Accode"] = new SelectList(_context.Accounts, "Acid", "Acid", balanceRec.Accode);
            ViewData["BraId"] = new SelectList(_context.Branches, "BraId", "BraId", balanceRec.BraId);
            return View(balanceRec);
        }

        // GET: BalanceRecs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BalanceRecs == null)
            {
                return NotFound();
            }

            var balanceRec = await _context.BalanceRecs.FindAsync(id);
            if (balanceRec == null)
            {
                return NotFound();
            }
            ViewData["Accode"] = new SelectList(_context.Accounts, "Acid", "Acid", balanceRec.Accode);
            ViewData["BraId"] = new SelectList(_context.Branches, "BraId", "BraId", balanceRec.BraId);
            return View(balanceRec);
        }

        // POST: BalanceRecs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Content,Amount,Term,BraId,Accode,Accr,Acdr")] BalanceRec balanceRec)
        {
            if (id != balanceRec.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(balanceRec);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BalanceRecExists(balanceRec.Id))
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
            ViewData["Accode"] = new SelectList(_context.Accounts, "Acid", "Acid", balanceRec.Accode);
            ViewData["BraId"] = new SelectList(_context.Branches, "BraId", "BraId", balanceRec.BraId);
            return View(balanceRec);
        }

        // GET: BalanceRecs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BalanceRecs == null)
            {
                return NotFound();
            }

            var balanceRec = await _context.BalanceRecs
                .Include(b => b.AccodeNavigation)
                .Include(b => b.Bra)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (balanceRec == null)
            {
                return NotFound();
            }

            return View(balanceRec);
        }

        // POST: BalanceRecs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BalanceRecs == null)
            {
                return Problem("Entity set 'QltcktContext.BalanceRecs'  is null.");
            }
            var balanceRec = await _context.BalanceRecs.FindAsync(id);
            if (balanceRec != null)
            {
                _context.BalanceRecs.Remove(balanceRec);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BalanceRecExists(int id)
        {
          return (_context.BalanceRecs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
