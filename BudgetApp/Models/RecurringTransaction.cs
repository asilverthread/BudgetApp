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
        enum RecurringTypes { //Not actually using this enum at the moment
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
        public ICollection<Transaction> Transactions { get; set;}
        [NotMapped]
        public string RecurringTransactionType;


        public void CreateTransactions() {
            switch (RecurringType) {
                case "Once":
                    //Once logic
                    break;
                case "Daily":
                    //Daily logic
                    break;
                case "Weekly":
                    //Daily logic
                    break;
                case "Monthly":
                    //Monthly logic
                    break;
                case "Yearly":
                    //Yearly logic
                    break;
                default:
                    //Null or invalid
                    break;
            }
        }
    }
}
