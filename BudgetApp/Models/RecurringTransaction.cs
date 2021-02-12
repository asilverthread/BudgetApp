using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetApp.Models
{
    public abstract class RecurringTransaction
    {
        enum RecurringTypes {
            Once,
            Daily,
            Weekly,
            Monthly, 
            Yearly
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Source")]
        public int RecurringTransactionId { get; set; }
        public string Source { get; set; }
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; } //Nullable for "Once" transactions
        public string RecurringType { get; set; } //Default Once
        public int? RecurringDay { get; set; } //Nullable
        
    }
}
