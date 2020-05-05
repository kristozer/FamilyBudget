using Microsoft.EntityFrameworkCore.Migrations;

namespace FamilyBudget.Infrastructure.Migrations
{
    public partial class Add_Income : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Income",
                table: "FinancialPeriods",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Income",
                table: "FinancialPeriods");
        }
    }
}
