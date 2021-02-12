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
    public class IncomeItemsController : Controller
    {
        private readonly BudgetContext _context;

        public IncomeItemsController(BudgetContext context)
        {
            _context = context;
        }

        // GET: IncomeItems
        public async Task<IActionResult> Index()
        {
            return View(await _context.IncomeItems.ToListAsync());
        }

        // GET: IncomeItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incomeItem = await _context.IncomeItems
                .FirstOrDefaultAsync(m => m.RecurringTransactionId == id);
            if (incomeItem == null)
            {
                return NotFound();
            }

            return View(incomeItem);
        }

        // GET: IncomeItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IncomeItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RecurringTransactionId,Source,Amount,StartDate,EndDate,RecurringType,RecurringDay")] IncomeItem incomeItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(incomeItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(incomeItem);
        }

        // GET: IncomeItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incomeItem = await _context.IncomeItems.FindAsync(id);
            if (incomeItem == null)
            {
                return NotFound();
            }
            return View(incomeItem);
        }

        // POST: IncomeItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RecurringTransactionId,Source,Amount,StartDate,EndDate,RecurringType,RecurringDay")] IncomeItem incomeItem)
        {
            if (id != incomeItem.RecurringTransactionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(incomeItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IncomeItemExists(incomeItem.RecurringTransactionId))
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
            return View(incomeItem);
        }

        // GET: IncomeItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incomeItem = await _context.IncomeItems
                .FirstOrDefaultAsync(m => m.RecurringTransactionId == id);
            if (incomeItem == null)
            {
                return NotFound();
            }

            return View(incomeItem);
        }

        // POST: IncomeItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var incomeItem = await _context.IncomeItems.FindAsync(id);
            _context.IncomeItems.Remove(incomeItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IncomeItemExists(int id)
        {
            return _context.IncomeItems.Any(e => e.RecurringTransactionId == id);
        }
    }
}
