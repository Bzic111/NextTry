using Microsoft.EntityFrameworkCore.Migrations;

namespace NextTry.Migrations
{
    public partial class TimeSheets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeSheet_Invoices_InvoiceId",
                table: "TimeSheet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TimeSheet",
                table: "TimeSheet");

            migrationBuilder.RenameTable(
                name: "TimeSheet",
                newName: "TimeSheets");

            migrationBuilder.RenameIndex(
                name: "IX_TimeSheet_InvoiceId",
                table: "TimeSheets",
                newName: "IX_TimeSheets_InvoiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimeSheets",
                table: "TimeSheets",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSheets_Invoices_InvoiceId",
                table: "TimeSheets",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeSheets_Invoices_InvoiceId",
                table: "TimeSheets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TimeSheets",
                table: "TimeSheets");

            migrationBuilder.RenameTable(
                name: "TimeSheets",
                newName: "TimeSheet");

            migrationBuilder.RenameIndex(
                name: "IX_TimeSheets_InvoiceId",
                table: "TimeSheet",
                newName: "IX_TimeSheet_InvoiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimeSheet",
                table: "TimeSheet",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSheet_Invoices_InvoiceId",
                table: "TimeSheet",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
