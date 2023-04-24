﻿// <auto-generated />
using System;
using DTLoanManagment.Models.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DTLoanManagment.Migrations.MainDB
{
    [DbContext(typeof(MainDBContext))]
    [Migration("20230413050316_testLedger")]
    partial class testLedger
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DTLoanManagment.Models.DBTableModels.Journal.Journal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AccType")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("varchar");

                    b.Property<DateTime>("ApprovalDate")
                        .HasColumnType("smalldatetime");

                    b.Property<int>("ApproveBy")
                        .HasColumnType("int");

                    b.Property<int>("BorrowerId")
                        .HasColumnType("int");

                    b.Property<double>("Credit")
                        .HasColumnType("float");

                    b.Property<double>("Debit")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2500)
                        .HasColumnType("varchar");

                    b.Property<DateTime>("JDate")
                        .HasColumnType("smalldatetime");

                    b.Property<int>("Jid")
                        .HasColumnType("int");

                    b.Property<int>("LedgerId")
                        .HasColumnType("int");

                    b.Property<int>("LoanId")
                        .HasColumnType("int");

                    b.Property<string>("Notify")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar");

                    b.Property<DateTime>("PostDate")
                        .HasColumnType("smalldatetime");

                    b.Property<int>("Tno")
                        .HasColumnType("int");

                    b.Property<int>("UpdateBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("smalldatetime");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<bool>("isLock")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("LedgerId");

                    b.ToTable("Journal", "dbo");
                });

            modelBuilder.Entity("DTLoanManagment.Models.DBTableModels.Journal.Ledger", b =>
                {
                    b.Property<int>("LedgerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LedgerId"));

                    b.Property<string>("Account")
                        .HasMaxLength(2)
                        .HasColumnType("varchar");

                    b.Property<double>("Balance")
                        .HasColumnType("float");

                    b.Property<string>("Courier")
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.Property<bool>("LedgerAcc")
                        .HasColumnType("bit");

                    b.Property<short>("LevelNo")
                        .HasColumnType("smallint");

                    b.Property<string>("MGroup")
                        .HasMaxLength(20)
                        .HasColumnType("varchar");

                    b.Property<int?>("MerchantId")
                        .HasColumnType("int");

                    b.Property<double>("OpeningBalance")
                        .HasColumnType("float");

                    b.Property<DateTime>("OpeningDate")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("SBName")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar");

                    b.Property<string>("Under")
                        .HasMaxLength(30)
                        .HasColumnType("varchar");

                    b.HasKey("LedgerId");

                    b.ToTable("Ledger", "dbo");
                });

            modelBuilder.Entity("DTLoanManagment.Models.Loan.SetLoanEmi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BorrowerId")
                        .HasColumnType("int");

                    b.Property<string>("BorrowerName")
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(30)
                        .HasColumnType("varchar");

                    b.Property<DateTime>("EMIRecoveryStartDate")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("InstallmentType")
                        .HasMaxLength(30)
                        .HasColumnType("varchar");

                    b.Property<double>("InterestRate")
                        .HasColumnType("float");

                    b.Property<double>("LoanAmount")
                        .HasColumnType("float");

                    b.Property<DateTime>("LoanDisbursementDate")
                        .HasColumnType("smalldatetime");

                    b.Property<double>("LoanProcessingFees")
                        .HasColumnType("float");

                    b.Property<int>("LoanSurveyId")
                        .HasColumnType("int");

                    b.Property<int>("NoOfEMIs")
                        .HasColumnType("int");

                    b.Property<double>("OtherCharges")
                        .HasColumnType("float");

                    b.Property<int>("PartnerId")
                        .HasColumnType("int");

                    b.Property<double>("PassBookCharges")
                        .HasColumnType("float");

                    b.Property<double>("PrincipalAmountEMI")
                        .HasColumnType("float");

                    b.Property<double>("PrincipalWithInterestAmountEMI")
                        .HasColumnType("float");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<double>("SavingsDepositAmount")
                        .HasColumnType("float");

                    b.Property<string>("SavingsInstallmentType")
                        .HasMaxLength(30)
                        .HasColumnType("varchar");

                    b.Property<double>("SavingsInterestRate")
                        .HasColumnType("float");

                    b.Property<int>("Tenure")
                        .HasColumnType("int");

                    b.Property<int>("TypeOfSavings")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(30)
                        .HasColumnType("varchar");

                    b.Property<double>("VatOnLoanProcessingFees")
                        .HasColumnType("float");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<bool>("isApproved")
                        .HasColumnType("bit");

                    b.Property<bool>("isDisbursed")
                        .HasColumnType("bit");

                    b.Property<bool>("isRejected")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("LoanEMISet", "loan");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DTLoanManagment.Models.DBTableModels.Journal.Journal", b =>
                {
                    b.HasOne("DTLoanManagment.Models.DBTableModels.Journal.Ledger", "Ledger")
                        .WithMany("Journals")
                        .HasForeignKey("LedgerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ledger");
                });

            modelBuilder.Entity("DTLoanManagment.Models.DBTableModels.Journal.Ledger", b =>
                {
                    b.Navigation("Journals");
                });
#pragma warning restore 612, 618
        }
    }
}
