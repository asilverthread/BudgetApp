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
    public class DebtRepaymentsController : Controller
    {
        private readonly BudgetContext _context;

        public DebtRepaymentsController(BudgetContext context)
        {
            _context = context;
        }

        // GET: DebtRepayments
        public async Task<IActionResult> Index()
        {
            return View(await _context.DebtRepayment.ToListAsync());
        }

        // GET: DebtRepayments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var debtRepayment = await _context.DebtRepayment
                .FirstOrDefaultAsync(m => m.RecurringTransactionId == id);
            if (debtRepayment == null)
            {
                return NotFound();
            }

            return View(debtRepayment);
        }

        // GET: DebtRepayments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DebtRepayments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TotalAmount,Minimum,PastDue,Interest,Limit,RecurringTransactionId,Source,Amount,StartDate,EndDate,RecurringType,RecurringDay")] DebtRepayment debtRepayment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(debtRepayment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(debtRepayment);
        }

        // GET: DebtRepayments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var debtRepayment = await _context.DebtRepayment.FindAsync(id);
            if (debtRepayment == null)
            {
                return NotFound();
            }
            return View(debtRepayment);
        }

        // POST: DebtRepayments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TotalAmount,Minimum,PastDue,Interest,Limit,RecurringTransactionId,Source,Amount,StartDate,EndDate,RecurringType,RecurringDay")] DebtRepayment debtRepayment)
        {
            if (id != debtRepayment.RecurringTransactionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(debtRepayment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DebtRepaymentExists(debtRepayment.RecurringTransactionId))
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
            return View(debtRepayment);
        }

        // GET: DebtRepayments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var debtRepayment = await _context.DebtRepayment
                .FirstOrDefaultAsync(m => m.RecurringTransactionId == id);
            if (debtRepayment == null)
            {
                return NotFound();
            }

            return View(debtRepayment);
        }

        // POST: DebtRepayments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var debtRepayment = await _context.DebtRepayment.FindAsync(id);
            _context.DebtRepayment.Remove(debtRepayment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DebtRepaymentExists(int id)
        {
            return _context.DebtRepayment.Any(e => e.RecurringTransactionId == id);
        }
    }
}
