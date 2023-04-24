using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DTLoanManagment.Migrations.MainDB
{
    /// <inheritdoc />
    public partial class updateLoanEmisetTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                schema: "loan",
                table: "LoanEMISet",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isActive",
                schema: "loan",
                table: "LoanEMISet");
        }
    }
}
