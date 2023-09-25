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
    public class LoanRecsController : Controller
    {
        private readonly QltcktContext _context;

        public LoanRecsController(QltcktContext context)
        {
            _context = context;
        }

        // GET: LoanRecs
        public async Task<IActionResult> Index()
        {
            var qltcktContext = _context.LoanRecs.Include(l => l.Ac).Include(l => l.Bra).Include(l => l.Pn);
            return View(await qltcktContext.ToListAsync());
        }

        // GET: LoanRecs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LoanRecs == null)
            {
                return NotFound();
            }

            var loanRec = await _context.LoanRecs
                .Include(l => l.Ac)
                .Include(l => l.Bra)
                .Include(l => l.Pn)
                .FirstOrDefaultAsync(m => m.LoanRecId == id);
            if (loanRec == null)
            {
                return NotFound();
            }

            return View(loanRec);
        }

        // GET: LoanRecs/Create
        public IActionResult Create()
        {
            ViewData["Acid"] = new SelectList(_context.Accounts, "Acid", "Acid");
            ViewData["BraId"] = new SelectList(_context.Branches, "BraId", "BraId");
            ViewData["PnId"] = new SelectList(_context.Partners, "PnId", "PnId");
            return View();
        }

        // POST: LoanRecs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LoanRecId,Desc,Amount,Time,InterestRate,Expried,RecentAmt,Uid,PnId,BraId,Acid")] LoanRec loanRec)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loanRec);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Acid"] = new SelectList(_context.Accounts, "Acid", "Acid", loanRec.Acid);
            ViewData["BraId"] = new SelectList(_context.Branches, "BraId", "BraId", loanRec.BraId);
            ViewData["PnId"] = new SelectList(_context.Partners, "PnId", "PnId", loanRec.PnId);
            return View(loanRec);
        }

        // GET: LoanRecs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LoanRecs == null)
            {
                return NotFound();
            }

            var loanRec = await _context.LoanRecs.FindAsync(id);
            if (loanRec == null)
            {
                return NotFound();
            }
            ViewData["Acid"] = new SelectList(_context.Accounts, "Acid", "Acid", loanRec.Acid);
            ViewData["BraId"] = new SelectList(_context.Branches, "BraId", "BraId", loanRec.BraId);
            ViewData["PnId"] = new SelectList(_context.Partners, "PnId", "PnId", loanRec.PnId);
            return View(loanRec);
        }

        // POST: LoanRecs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LoanRecId,Desc,Amount,Time,InterestRate,Expried,RecentAmt,Uid,PnId,BraId,Acid")] LoanRec loanRec)
        {
            if (id != loanRec.LoanRecId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loanRec);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoanRecExists(loanRec.LoanRecId))
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
            ViewData["Acid"] = new SelectList(_context.Accounts, "Acid", "Acid", loanRec.Acid);
            ViewData["BraId"] = new SelectList(_context.Branches, "BraId", "BraId", loanRec.BraId);
            ViewData["PnId"] = new SelectList(_context.Partners, "PnId", "PnId", loanRec.PnId);
            return View(loanRec);
        }

        // GET: LoanRecs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LoanRecs == null)
            {
                return NotFound();
            }

            var loanRec = await _context.LoanRecs
                .Include(l => l.Ac)
                .Include(l => l.Bra)
                .Include(l => l.Pn)
                .FirstOrDefaultAsync(m => m.LoanRecId == id);
            if (loanRec == null)
            {
                return NotFound();
            }

            return View(loanRec);
        }

        // POST: LoanRecs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LoanRecs == null)
            {
                return Problem("Entity set 'QltcktContext.LoanRecs'  is null.");
            }
            var loanRec = await _context.LoanRecs.FindAsync(id);
            if (loanRec != null)
            {
                _context.LoanRecs.Remove(loanRec);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoanRecExists(int id)
        {
          return (_context.LoanRecs?.Any(e => e.LoanRecId == id)).GetValueOrDefault();
        }
    }
}
