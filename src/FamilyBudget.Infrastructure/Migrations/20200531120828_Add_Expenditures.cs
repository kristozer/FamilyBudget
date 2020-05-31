using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FamilyBudget.Infrastructure.Migrations
{
    public partial class Add_Expenditures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Expenditure",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<decimal>(nullable: false),
                    FinancialPeriodId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenditure", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expenditure_FinancialPeriods_FinancialPeriodId",
                        column: x => x.FinancialPeriodId,
                        principalTable: "FinancialPeriods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expenditure_FinancialPeriodId",
                table: "Expenditure",
                column: "FinancialPeriodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expenditure");
        }
    }
}
