using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankManagement.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
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
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankEmployees",
                columns: table => new
                {
                    BankEmployee1Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateEmployed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatePromoted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeDepartment = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankEmployees", x => x.BankEmployee1Id);
                });

            migrationBuilder.CreateTable(
                name: "BankFees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SavingsFees = table.Column<int>(type: "int", nullable: false),
                    SavingsCommission = table.Column<int>(type: "int", nullable: false),
                    DepositFees = table.Column<int>(type: "int", nullable: false),
                    DepositCommission = table.Column<int>(type: "int", nullable: false),
                    CurrentFees = table.Column<int>(type: "int", nullable: false),
                    CurrentCommissiion = table.Column<int>(type: "int", nullable: false),
                    CheckingFees = table.Column<int>(type: "int", nullable: false),
                    CheckingCommissiion = table.Column<int>(type: "int", nullable: false),
                    BankCharges = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankFees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AmountWithdrawn = table.Column<int>(type: "int", nullable: false),
                    AccountOwner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateWithdrawn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Depositorname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AmountDeposited = table.Column<int>(type: "int", nullable: false),
                    DateDeposited = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NextOfKins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankLoanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NextOfKins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeSalaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MonthlySalary = table.Column<int>(type: "int", nullable: false),
                    TaxPayable = table.Column<int>(type: "int", nullable: false),
                    AnualSalary = table.Column<int>(type: "int", nullable: false),
                    GrossPay = table.Column<int>(type: "int", nullable: false),
                    BankEmployee1Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSalaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeSalaries_BankEmployees_BankEmployee1Id",
                        column: x => x.BankEmployee1Id,
                        principalTable: "BankEmployees",
                        principalColumn: "BankEmployee1Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BankCustomers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankNumber = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Profession = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankCustomerNextOfKinId = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Credit = table.Column<int>(type: "int", nullable: false),
                    Debit = table.Column<int>(type: "int", nullable: false),
                    BankAddressId = table.Column<int>(type: "int", nullable: false),
                    DateRegistered = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankCustomers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankCustomers_Addresses_BankAddressId",
                        column: x => x.BankAddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BankCustomers_NextOfKins_BankCustomerNextOfKinId",
                        column: x => x.BankCustomerNextOfKinId,
                        principalTable: "NextOfKins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BankLoan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAccountViable = table.Column<bool>(type: "bit", nullable: false),
                    BankAccount = table.Column<int>(type: "int", nullable: false),
                    AmountRequested = table.Column<int>(type: "int", nullable: false),
                    BankCustomerNextOfKinId = table.Column<int>(type: "int", nullable: false),
                    RepaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccountType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InterestOnLoan = table.Column<int>(type: "int", nullable: false),
                    BankDeposit = table.Column<int>(type: "int", nullable: false),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoanDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankLoan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankLoan_NextOfKins_BankCustomerNextOfKinId",
                        column: x => x.BankCustomerNextOfKinId,
                        principalTable: "NextOfKins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BankCustomers_BankAddressId",
                table: "BankCustomers",
                column: "BankAddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BankCustomers_BankCustomerNextOfKinId",
                table: "BankCustomers",
                column: "BankCustomerNextOfKinId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BankLoan_BankCustomerNextOfKinId",
                table: "BankLoan",
                column: "BankCustomerNextOfKinId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSalaries_BankEmployee1Id",
                table: "EmployeeSalaries",
                column: "BankEmployee1Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BankCustomers");

            migrationBuilder.DropTable(
                name: "BankFees");

            migrationBuilder.DropTable(
                name: "BankLoan");

            migrationBuilder.DropTable(
                name: "BankLogs");

            migrationBuilder.DropTable(
                name: "EmployeeSalaries");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "NextOfKins");

            migrationBuilder.DropTable(
                name: "BankEmployees");
        }
    }
}
