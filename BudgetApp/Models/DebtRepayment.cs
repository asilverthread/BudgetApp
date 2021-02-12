using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetApp.Models
{
    public class DebtRepayment : RecurringTransaction
    {
        [DataType(DataType.Currency)]
        public decimal TotalAmount { get; set; }
        [DataType(DataType.Currency)]
        public decimal Minimum { get; set; }
        [DataType(DataType.Currency)]
        public decimal PastDue { get; set; }
        public decimal Interest { get; set; }
        [DataType(DataType.Currency)]
        public decimal Limit { get; set; }
    }
}
