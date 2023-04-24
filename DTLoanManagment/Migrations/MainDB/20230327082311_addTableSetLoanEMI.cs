using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DTLoanManagment.Migrations.MainDB
{
    /// <inheritdoc />
    public partial class addTableSetLoanEMI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "loan");

            migrationBuilder.CreateTable(
                name: "LoanEMISet",
                schema: "loan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BorrowerId = table.Column<int>(type: "int", nullable: false),
                    BorrowerName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    PartnerId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    LoanAmount = table.Column<double>(type: "float", nullable: false),
                    Tenure = table.Column<int>(type: "int", nullable: false),
                    InstallmentType = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    NoOfEMIs = table.Column<int>(type: "int", nullable: false),
                    LoanProcessingFees = table.Column<double>(type: "float", nullable: false),
                    PassBookCharges = table.Column<double>(type: "float", nullable: false),
                    OtherCharges = table.Column<double>(type: "float", nullable: false),
                    VatOnLoanProcessingFees = table.Column<double>(type: "float", nullable: false),
                    InterestRate = table.Column<double>(type: "float", nullable: false),
                    PrincipalAmountEMI = table.Column<double>(type: "float", nullable: false),
                    PrincipalWithInterestAmountEMI = table.Column<double>(type: "float", nullable: false),
                    SavingsDepositAmount = table.Column<double>(type: "float", nullable: false),
                    SavingsInstallmentType = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    TypeOfSavings = table.Column<int>(type: "int", nullable: false),
                    SavingsInterestRate = table.Column<double>(type: "float", nullable: false),
                    LoanDisbursementDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    EMIRecoveryStartDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedBy = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "smalldatetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanEMISet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoanEMISet",
                schema: "loan");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
