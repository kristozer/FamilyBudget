using Microsoft.EntityFrameworkCore.Migrations;

namespace FamilyBudget.Infrastructure.Migrations
{
    public partial class ExpandExpenditure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "Expenditures");

            migrationBuilder.AddColumn<decimal>(
                name: "PlannedToSpendValue",
                table: "Expenditures",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SpendValue",
                table: "Expenditures",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlannedToSpendValue",
                table: "Expenditures");

            migrationBuilder.DropColumn(
                name: "SpendValue",
                table: "Expenditures");

            migrationBuilder.AddColumn<decimal>(
                name: "Value",
                table: "Expenditures",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
