using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetApp.Models
{
    public class Transaction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionId { get; set; }

        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }
        [DataType(DataType.Date)]
        public DateTime EffectiveDate { get; set; }
        public string Description { get; set; }
        public string Memo { get; set; }
        public string Account { get; set; }
        public string Owner { get; set; }
        public string CheckNumber { get; set; }
        public int? RecurringTransactionId { get; set; }
        public RecurringTransaction? RecurringTransaction { get; set; }
        
    }
}
