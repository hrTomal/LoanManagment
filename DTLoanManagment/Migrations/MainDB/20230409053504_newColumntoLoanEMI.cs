using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DTLoanManagment.Migrations.MainDB
{
    /// <inheritdoc />
    public partial class newColumntoLoanEMI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isDisbursed",
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
                name: "isDisbursed",
                schema: "loan",
                table: "LoanEMISet");
        }
    }
}
