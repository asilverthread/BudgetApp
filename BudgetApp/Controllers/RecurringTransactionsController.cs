using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BudgetApp.Data;
using BudgetApp.Models;

namespace BudgetApp.Controllers
{
    public class RecurringTransactionsController : Controller
    {
        private readonly BudgetContext _context;

        public RecurringTransactionsController(BudgetContext context)
        {
            _context = context;
        }

        // GET: RecurringTransactions
        public async Task<IActionResult> Index()
        {
            return View(await _context.RecurringTransactions.ToListAsync());
        }

        // GET: RecurringTransactions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recurringTransaction = await _context.RecurringTransactions
                .FirstOrDefaultAsync(m => m.RecurringTransactionId == id);
            if (recurringTransaction == null)
            {
                return NotFound();
            }

            return View(recurringTransaction);
        }

        // GET: RecurringTransactions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RecurringTransactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RecurringTransactionId,Source,Amount,StartDate,EndDate,RecurringType,RecurringDay")] RecurringTransaction recurringTransaction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recurringTransaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recurringTransaction);
        }

        // GET: RecurringTransactions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recurringTransaction = await _context.RecurringTransactions.FindAsync(id);
            if (recurringTransaction == null)
            {
                return NotFound();
            }
            return View(recurringTransaction);
        }

        // POST: RecurringTransactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RecurringTransactionId,Source,Amount,StartDate,EndDate,RecurringType,RecurringDay")] RecurringTransaction recurringTransaction)
        {
            if (id != recurringTransaction.RecurringTransactionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recurringTransaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecurringTransactionExists(recurringTransaction.RecurringTransactionId))
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
            return View(recurringTransaction);
        }

        // GET: RecurringTransactions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recurringTransaction = await _context.RecurringTransactions
                .FirstOrDefaultAsync(m => m.RecurringTransactionId == id);
            if (recurringTransaction == null)
            {
                return NotFound();
            }

            return View(recurringTransaction);
        }

        // POST: RecurringTransactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recurringTransaction = await _context.RecurringTransactions.FindAsync(id);
            _context.RecurringTransactions.Remove(recurringTransaction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecurringTransactionExists(int id)
        {
            return _context.RecurringTransactions.Any(e => e.RecurringTransactionId == id);
        }
    }
}
