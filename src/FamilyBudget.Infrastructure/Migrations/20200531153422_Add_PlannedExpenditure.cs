using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FamilyBudget.Infrastructure.Migrations
{
    public partial class Add_PlannedExpenditure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlannedExpenditureId",
                table: "Expenditures",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PlannedExpenditures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<decimal>(nullable: false),
                    Period = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlannedExpenditures", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expenditures_PlannedExpenditureId",
                table: "Expenditures",
                column: "PlannedExpenditureId",
                unique: true,
                filter: "[PlannedExpenditureId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenditures_PlannedExpenditures_PlannedExpenditureId",
                table: "Expenditures",
                column: "PlannedExpenditureId",
                principalTable: "PlannedExpenditures",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenditures_PlannedExpenditures_PlannedExpenditureId",
                table: "Expenditures");

            migrationBuilder.DropTable(
                name: "PlannedExpenditures");

            migrationBuilder.DropIndex(
                name: "IX_Expenditures_PlannedExpenditureId",
                table: "Expenditures");

            migrationBuilder.DropColumn(
                name: "PlannedExpenditureId",
                table: "Expenditures");
        }
    }
}
