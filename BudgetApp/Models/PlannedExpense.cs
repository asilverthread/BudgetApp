using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BudgetApp.Models
{
    public class PlannedExpense
    {
        public int PlannedExpenseId { get; set; }
        public string Expense { get; set; }
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }
        [DataType(DataType.Date)]
        public DateTime ExpenseDate;
    }
}
