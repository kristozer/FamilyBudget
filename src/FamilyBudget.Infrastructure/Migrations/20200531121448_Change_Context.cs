using Microsoft.EntityFrameworkCore.Migrations;

namespace FamilyBudget.Infrastructure.Migrations
{
    public partial class Change_Context : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenditure_FinancialPeriods_FinancialPeriodId",
                table: "Expenditure");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Expenditure",
                table: "Expenditure");

            migrationBuilder.RenameTable(
                name: "Expenditure",
                newName: "Expenditures");

            migrationBuilder.RenameIndex(
                name: "IX_Expenditure_FinancialPeriodId",
                table: "Expenditures",
                newName: "IX_Expenditures_FinancialPeriodId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Expenditures",
                table: "Expenditures",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenditures_FinancialPeriods_FinancialPeriodId",
                table: "Expenditures",
                column: "FinancialPeriodId",
                principalTable: "FinancialPeriods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenditures_FinancialPeriods_FinancialPeriodId",
                table: "Expenditures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Expenditures",
                table: "Expenditures");

            migrationBuilder.RenameTable(
                name: "Expenditures",
                newName: "Expenditure");

            migrationBuilder.RenameIndex(
                name: "IX_Expenditures_FinancialPeriodId",
                table: "Expenditure",
                newName: "IX_Expenditure_FinancialPeriodId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Expenditure",
                table: "Expenditure",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenditure_FinancialPeriods_FinancialPeriodId",
                table: "Expenditure",
                column: "FinancialPeriodId",
                principalTable: "FinancialPeriods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
