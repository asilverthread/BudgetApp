using Microsoft.EntityFrameworkCore.Migrations;

namespace BudgetApp.Migrations
{
    public partial class removedfield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_RecurringTransactions_IncomeItemRecurringTransactionId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_IncomeItemRecurringTransactionId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "IncomeItemRecurringTransactionId",
                table: "Transactions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IncomeItemRecurringTransactionId",
                table: "Transactions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_IncomeItemRecurringTransactionId",
                table: "Transactions",
                column: "IncomeItemRecurringTransactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_RecurringTransactions_IncomeItemRecurringTransactionId",
                table: "Transactions",
                column: "IncomeItemRecurringTransactionId",
                principalTable: "RecurringTransactions",
                principalColumn: "RecurringTransactionId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
