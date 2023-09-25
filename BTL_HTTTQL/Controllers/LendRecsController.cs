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
    public class LendRecsController : Controller
    {
        private readonly QltcktContext _context;

        public LendRecsController(QltcktContext context)
        {
            _context = context;
        }

        // GET: LendRecs
        public async Task<IActionResult> Index()
        {
            var qltcktContext = _context.LendRecs.Include(l => l.Ac).Include(l => l.Bra).Include(l => l.Pn);
            return View(await qltcktContext.ToListAsync());
        }

        // GET: LendRecs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LendRecs == null)
            {
                return NotFound();
            }

            var lendRec = await _context.LendRecs
                .Include(l => l.Ac)
                .Include(l => l.Bra)
                .Include(l => l.Pn)
                .FirstOrDefaultAsync(m => m.LendRecId == id);
            if (lendRec == null)
            {
                return NotFound();
            }

            return View(lendRec);
        }

        // GET: LendRecs/Create
        public IActionResult Create()
        {
            ViewData["Acid"] = new SelectList(_context.Accounts, "Acid", "Acid");
            ViewData["BraId"] = new SelectList(_context.Branches, "BraId", "BraId");
            ViewData["PnId"] = new SelectList(_context.Partners, "PnId", "PnId");
            return View();
        }

        // POST: LendRecs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LendRecId,Desc,Amount,Time,InterestRate,Expired,RecentAmt,Uid,PnId,BraId,Acid")] LendRec lendRec)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lendRec);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Acid"] = new SelectList(_context.Accounts, "Acid", "Acid", lendRec.Acid);
            ViewData["BraId"] = new SelectList(_context.Branches, "BraId", "BraId", lendRec.BraId);
            ViewData["PnId"] = new SelectList(_context.Partners, "PnId", "PnId", lendRec.PnId);
            return View(lendRec);
        }

        // GET: LendRecs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LendRecs == null)
            {
                return NotFound();
            }

            var lendRec = await _context.LendRecs.FindAsync(id);
            if (lendRec == null)
            {
                return NotFound();
            }
            ViewData["Acid"] = new SelectList(_context.Accounts, "Acid", "Acid", lendRec.Acid);
            ViewData["BraId"] = new SelectList(_context.Branches, "BraId", "BraId", lendRec.BraId);
            ViewData["PnId"] = new SelectList(_context.Partners, "PnId", "PnId", lendRec.PnId);
            return View(lendRec);
        }

        // POST: LendRecs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LendRecId,Desc,Amount,Time,InterestRate,Expired,RecentAmt,Uid,PnId,BraId,Acid")] LendRec lendRec)
        {
            if (id != lendRec.LendRecId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lendRec);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LendRecExists(lendRec.LendRecId))
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
            ViewData["Acid"] = new SelectList(_context.Accounts, "Acid", "Acid", lendRec.Acid);
            ViewData["BraId"] = new SelectList(_context.Branches, "BraId", "BraId", lendRec.BraId);
            ViewData["PnId"] = new SelectList(_context.Partners, "PnId", "PnId", lendRec.PnId);
            return View(lendRec);
        }

        // GET: LendRecs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LendRecs == null)
            {
                return NotFound();
            }

            var lendRec = await _context.LendRecs
                .Include(l => l.Ac)
                .Include(l => l.Bra)
                .Include(l => l.Pn)
                .FirstOrDefaultAsync(m => m.LendRecId == id);
            if (lendRec == null)
            {
                return NotFound();
            }

            return View(lendRec);
        }

        // POST: LendRecs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LendRecs == null)
            {
                return Problem("Entity set 'QltcktContext.LendRecs'  is null.");
            }
            var lendRec = await _context.LendRecs.FindAsync(id);
            if (lendRec != null)
            {
                _context.LendRecs.Remove(lendRec);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LendRecExists(int id)
        {
          return (_context.LendRecs?.Any(e => e.LendRecId == id)).GetValueOrDefault();
        }
    }
}
