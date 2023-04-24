using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DTLoanManagment.Migrations.MainDB
{
    /// <inheritdoc />
    public partial class testLedger : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OpeningDate",
                schema: "dbo",
                table: "Ledger",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "MerchantId",
                schema: "dbo",
                table: "Ledger",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OpeningDate",
                schema: "dbo",
                table: "Ledger",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<int>(
                name: "MerchantId",
                schema: "dbo",
                table: "Ledger",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
