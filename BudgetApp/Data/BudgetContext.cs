using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BudgetApp.Models;


namespace BudgetApp.Data
{
    public class BudgetContext : DbContext
    {
        public BudgetContext(DbContextOptions<BudgetContext> options) 
            : base(options)
        { 
        }

        public DbSet<RecurringTransaction> RecurringTransactions { get; set; }
        public DbSet<IncomeItem> IncomeItems { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<BudgetApp.Models.DebtRepayment> DebtRepayment { get; set; }
        public DbSet<BudgetApp.Models.MonthlyBill> MonthlyBill { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder) { 
        
        //}

    }
}
