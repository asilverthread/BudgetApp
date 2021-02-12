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
    public class MonthlyBillsController : Controller
    {
        private readonly BudgetContext _context;

        public MonthlyBillsController(BudgetContext context)
        {
            _context = context;
        }

        // GET: MonthlyBills
        public async Task<IActionResult> Index()
        {
            return View(await _context.MonthlyBill.ToListAsync());
        }

        // GET: MonthlyBills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monthlyBill = await _context.MonthlyBill
                .FirstOrDefaultAsync(m => m.RecurringTransactionId == id);
            if (monthlyBill == null)
            {
                return NotFound();
            }

            return View(monthlyBill);
        }

        // GET: MonthlyBills/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MonthlyBills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SpreadBudget,RecurringTransactionId,Source,Amount,StartDate,EndDate,RecurringType,RecurringDay")] MonthlyBill monthlyBill)
        {
            if (ModelState.IsValid)
            {
                _context.Add(monthlyBill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(monthlyBill);
        }

        // GET: MonthlyBills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monthlyBill = await _context.MonthlyBill.FindAsync(id);
            if (monthlyBill == null)
            {
                return NotFound();
            }
            return View(monthlyBill);
        }

        // POST: MonthlyBills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SpreadBudget,RecurringTransactionId,Source,Amount,StartDate,EndDate,RecurringType,RecurringDay")] MonthlyBill monthlyBill)
        {
            if (id != monthlyBill.RecurringTransactionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(monthlyBill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonthlyBillExists(monthlyBill.RecurringTransactionId))
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
            return View(monthlyBill);
        }

        // GET: MonthlyBills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monthlyBill = await _context.MonthlyBill
                .FirstOrDefaultAsync(m => m.RecurringTransactionId == id);
            if (monthlyBill == null)
            {
                return NotFound();
            }

            return View(monthlyBill);
        }

        // POST: MonthlyBills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var monthlyBill = await _context.MonthlyBill.FindAsync(id);
            _context.MonthlyBill.Remove(monthlyBill);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MonthlyBillExists(int id)
        {
            return _context.MonthlyBill.Any(e => e.RecurringTransactionId == id);
        }
    }
}
