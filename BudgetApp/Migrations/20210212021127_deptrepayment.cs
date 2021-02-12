using Microsoft.EntityFrameworkCore.Migrations;

namespace BudgetApp.Migrations
{
    public partial class deptrepayment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Interest",
                table: "RecurringTransactions",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Limit",
                table: "RecurringTransactions",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Minimum",
                table: "RecurringTransactions",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PastDue",
                table: "RecurringTransactions",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                table: "RecurringTransactions",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Interest",
                table: "RecurringTransactions");

            migrationBuilder.DropColumn(
                name: "Limit",
                table: "RecurringTransactions");

            migrationBuilder.DropColumn(
                name: "Minimum",
                table: "RecurringTransactions");

            migrationBuilder.DropColumn(
                name: "PastDue",
                table: "RecurringTransactions");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "RecurringTransactions");
        }
    }
}
