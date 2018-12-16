using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoESW.Data;
using ProjetoESW.Models;

namespace ProjetoESW.Controllers
{
    public class AccountMovementsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountMovementsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AccountMovements
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AccountMovements.Include(a => a.Accounting);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AccountMovements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountMovements = await _context.AccountMovements
                .Include(a => a.Accounting)
                .FirstOrDefaultAsync(m => m.AccountMovementsID == id);
            if (accountMovements == null)
            {
                return NotFound();
            }

            return View(accountMovements);
        }

        // GET: AccountMovements/Create
        public IActionResult Create()
        {
            ViewData["AccountingID"] = new SelectList(_context.Accounting, "AccountingID", "Description");
            return View();
        }

        // POST: AccountMovements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccountMovementsID,AccountingID,Description,Ammount")] AccountMovements accountMovements)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accountMovements);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountingID"] = new SelectList(_context.Accounting, "AccountingID", "Description", accountMovements.AccountingID);
            return View(accountMovements);
        }

        [HttpPost]
        public async Task<IActionResult> MyCreate(int AccountID, decimal Value, string Description)
        {
            AccountMovements accountMovements = new AccountMovements(){AccountingID = AccountID, Ammount = Value, Description = Description};
            _context.Add(accountMovements);
            await _context.SaveChangesAsync();

            return Accepted();
        }

        // GET: AccountMovements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountMovements = await _context.AccountMovements.FindAsync(id);
            if (accountMovements == null)
            {
                return NotFound();
            }
            ViewData["AccountingID"] = new SelectList(_context.Accounting, "AccountingID", "Description", accountMovements.AccountingID);
            return View(accountMovements);
        }

        // POST: AccountMovements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AccountMovementsID,AccountingID,Description,Ammount")] AccountMovements accountMovements)
        {
            if (id != accountMovements.AccountMovementsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accountMovements);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountMovementsExists(accountMovements.AccountMovementsID))
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
            ViewData["AccountingID"] = new SelectList(_context.Accounting, "AccountingID", "Description", accountMovements.AccountingID);
            return View(accountMovements);
        }

        // GET: AccountMovements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var accountMovements = await _context.AccountMovements.FindAsync(id);
            _context.AccountMovements.Remove(accountMovements);
            await _context.SaveChangesAsync();
            return Accepted();
        }
        
        private bool AccountMovementsExists(int id)
        {
            return _context.AccountMovements.Any(e => e.AccountMovementsID == id);
        }
    }
}
