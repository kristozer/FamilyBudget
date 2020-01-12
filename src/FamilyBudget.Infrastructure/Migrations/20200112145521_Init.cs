using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FamilyBudget.Infrastructure.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FinancialPeriods",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    PeriodBegin = table.Column<DateTime>(nullable: false),
                    PeriodEnd = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialPeriods", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "FinancialPeriods",
                columns: new[] { "Id", "Created", "Modified", "Name", "PeriodBegin", "PeriodEnd" },
                values: new object[] { 1, new DateTime(2020, 1, 12, 14, 55, 10, 429, DateTimeKind.Utc).AddTicks(249), new DateTime(2020, 1, 12, 14, 55, 10, 429, DateTimeKind.Utc).AddTicks(262), "First", new DateTime(2020, 1, 12, 14, 55, 10, 429, DateTimeKind.Utc).AddTicks(263), new DateTime(2020, 1, 27, 14, 55, 10, 429, DateTimeKind.Utc).AddTicks(263) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FinancialPeriods");
        }
    }
}
