using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace SisVenda.Server.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bank",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(32)", nullable: false),
                    DtDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    DtRegister = table.Column<DateTime>(type: "datetime", nullable: false),
                    Name = table.Column<string>(type: "char(150)", nullable: true),
                    Code = table.Column<string>(type: "char(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bank", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(32)", nullable: false),
                    DtDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    DtRegister = table.Column<DateTime>(type: "datetime", nullable: false),
                    Name = table.Column<string>(type: "char(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentStatus",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(32)", nullable: false),
                    DtDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    DtRegister = table.Column<DateTime>(type: "datetime", nullable: false),
                    Description = table.Column<string>(type: "char(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(32)", nullable: false),
                    DtDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    DtRegister = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsCustomer = table.Column<bool>(nullable: false),
                    IsSupplier = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(type: "char(150)", nullable: false),
                    Contact = table.Column<string>(type: "char(150)", nullable: false),
                    CPF = table.Column<string>(type: "char(11)", nullable: false),
                    CNPJ = table.Column<string>(type: "char(14)", nullable: false),
                    Street = table.Column<string>(type: "char(100)", nullable: false),
                    Number = table.Column<string>(type: "char(10)", nullable: false),
                    Neighborhood = table.Column<string>(type: "char(30)", nullable: false),
                    City = table.Column<string>(type: "char(50)", nullable: false),
                    State = table.Column<string>(type: "char(2)", nullable: false),
                    ZipCode = table.Column<string>(type: "char(10)", nullable: false),
                    AdressEmail = table.Column<string>(type: "char(50)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "char(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(32)", nullable: false),
                    DtDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    DtRegister = table.Column<DateTime>(type: "datetime", nullable: false),
                    Name = table.Column<string>(type: "varchar(150)", nullable: false),
                    Description = table.Column<string>(type: "varchar(150)", nullable: false),
                    QuantityStock = table.Column<decimal>(type: "decimal(10, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnitMeasurement",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(32)", nullable: false),
                    DtDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    DtRegister = table.Column<DateTime>(type: "datetime", nullable: false),
                    Name = table.Column<string>(type: "varchar(150)", nullable: false),
                    QuantityLosses = table.Column<decimal>(type: "decimal(10, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitMeasurement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(32)", nullable: false),
                    DtDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    DtRegister = table.Column<DateTime>(type: "datetime", nullable: false),
                    Name = table.Column<string>(type: "char(150)", nullable: false),
                    User = table.Column<string>(type: "char(20)", nullable: false),
                    Password = table.Column<string>(type: "char(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankAgency",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(32)", nullable: false),
                    DtDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    DtRegister = table.Column<DateTime>(type: "datetime", nullable: false),
                    Name = table.Column<string>(type: "char(150)", nullable: true),
                    Code = table.Column<string>(type: "char(10)", nullable: true),
                    BankId = table.Column<string>(type: "varchar(32)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAgency", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankAgency_Bank_BankId",
                        column: x => x.BankId,
                        principalTable: "Bank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(32)", nullable: false),
                    DtDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    DtRegister = table.Column<DateTime>(type: "datetime", nullable: false),
                    PeopleId = table.Column<string>(nullable: false),
                    DtMoviment = table.Column<DateTime>(type: "datetime", nullable: false),
                    PaymentStatusId = table.Column<string>(nullable: false),
                    AmountDiscount = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    AmountAddition = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    Description = table.Column<string>(type: "varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchases_PaymentStatus_PaymentStatusId",
                        column: x => x.PaymentStatusId,
                        principalTable: "PaymentStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchases_People_PeopleId",
                        column: x => x.PeopleId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(32)", nullable: false),
                    DtDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    DtRegister = table.Column<DateTime>(type: "datetime", nullable: false),
                    PeopleId = table.Column<string>(nullable: false),
                    DtMoviment = table.Column<DateTime>(type: "datetime", nullable: false),
                    PaymentStatusId = table.Column<string>(nullable: false),
                    AmountDiscount = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    AmountAddition = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    Description = table.Column<string>(type: "varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_PaymentStatus_PaymentStatusId",
                        column: x => x.PaymentStatusId,
                        principalTable: "PaymentStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_People_PeopleId",
                        column: x => x.PeopleId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductsProfile",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(32)", nullable: false),
                    DtDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    DtRegister = table.Column<DateTime>(type: "datetime", nullable: false),
                    UnitMeasurementId = table.Column<string>(type: "varchar(32)", nullable: false),
                    ProductsId = table.Column<string>(type: "varchar(32)", nullable: false),
                    BarCode = table.Column<string>(type: "char(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsProfile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductsProfile_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsProfile_UnitMeasurement_UnitMeasurementId",
                        column: x => x.UnitMeasurementId,
                        principalTable: "UnitMeasurement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BankAccount",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(32)", nullable: false),
                    DtDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    DtRegister = table.Column<DateTime>(type: "datetime", nullable: false),
                    Account = table.Column<string>(type: "char(25)", nullable: true),
                    BankAgencyId = table.Column<string>(type: "varchar(32)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankAccount_BankAgency_BankAgencyId",
                        column: x => x.BankAgencyId,
                        principalTable: "BankAgency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchasePayments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(32)", nullable: false),
                    DtDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    DtRegister = table.Column<DateTime>(type: "datetime", nullable: false),
                    DtPaymentForecast = table.Column<DateTime>(type: "datetime", nullable: false),
                    DtPayment = table.Column<DateTime>(type: "datetime", nullable: true),
                    Value = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    PaymentMethodsId = table.Column<string>(nullable: false),
                    PurchasesId = table.Column<string>(type: "varchar(32)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasePayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchasePayments_PaymentMethods_PaymentMethodsId",
                        column: x => x.PaymentMethodsId,
                        principalTable: "PaymentMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchasePayments_Purchases_PurchasesId",
                        column: x => x.PurchasesId,
                        principalTable: "Purchases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesPayment",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(32)", nullable: false),
                    DtDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    DtRegister = table.Column<DateTime>(type: "datetime", nullable: false),
                    DtPaymentForecast = table.Column<DateTime>(type: "datetime", nullable: false),
                    DtPayment = table.Column<DateTime>(type: "datetime", nullable: true),
                    Value = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    PaymentMethodsId = table.Column<string>(nullable: false),
                    SalesId = table.Column<string>(type: "varchar(32)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesPayment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesPayment_PaymentMethods_PaymentMethodsId",
                        column: x => x.PaymentMethodsId,
                        principalTable: "PaymentMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesPayment_Sales_SalesId",
                        column: x => x.SalesId,
                        principalTable: "Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Losses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(32)", nullable: false),
                    DtDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    DtRegister = table.Column<DateTime>(type: "datetime", nullable: false),
                    ProductsProfileId = table.Column<string>(type: "varchar(32)", nullable: false),
                    DtMoviment = table.Column<DateTime>(type: "datetime", nullable: false),
                    Description = table.Column<string>(type: "varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Losses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Losses_ProductsProfile_ProductsProfileId",
                        column: x => x.ProductsProfileId,
                        principalTable: "ProductsProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductsPrices",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(32)", nullable: false),
                    DtDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    DtRegister = table.Column<DateTime>(type: "datetime", nullable: false),
                    ProductsProfileId = table.Column<string>(type: "varchar(32)", nullable: false),
                    DtEffective = table.Column<DateTime>(type: "datetime", nullable: false),
                    AveragePurchaseCost = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    SalesPrice = table.Column<decimal>(type: "decimal(10, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductsPrices_ProductsProfile_ProductsProfileId",
                        column: x => x.ProductsProfileId,
                        principalTable: "ProductsProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchasesItems",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(32)", nullable: false),
                    DtDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    DtRegister = table.Column<DateTime>(type: "datetime", nullable: false),
                    ProductsProfileId = table.Column<string>(nullable: false),
                    QuantityItem = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    CostPrice = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    PurchasesId = table.Column<string>(type: "varchar(32)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasesItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchasesItems_ProductsProfile_ProductsProfileId",
                        column: x => x.ProductsProfileId,
                        principalTable: "ProductsProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchasesItems_Purchases_PurchasesId",
                        column: x => x.PurchasesId,
                        principalTable: "Purchases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesItems",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(32)", nullable: false),
                    DtDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    DtRegister = table.Column<DateTime>(type: "datetime", nullable: false),
                    ProductsProfileId = table.Column<string>(nullable: false),
                    QuantityItem = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    CostPrice = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    SalesId = table.Column<string>(type: "varchar(32)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesItems_ProductsProfile_ProductsProfileId",
                        column: x => x.ProductsProfileId,
                        principalTable: "ProductsProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesItems_Sales_SalesId",
                        column: x => x.SalesId,
                        principalTable: "Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DtDeleted", "DtRegister", "Name", "Password", "User" },
                values: new object[] { "603aca511c2d405597e8de3c3fcc1601", null, new DateTime(2020, 6, 14, 8, 51, 45, 889, DateTimeKind.Local).AddTicks(3661), "Administrador", "123", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_BankAccount_BankAgencyId",
                table: "BankAccount",
                column: "BankAgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAgency_BankId",
                table: "BankAgency",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Losses_ProductsProfileId",
                table: "Losses",
                column: "ProductsProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsPrices_ProductsProfileId",
                table: "ProductsPrices",
                column: "ProductsProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsProfile_ProductsId",
                table: "ProductsProfile",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsProfile_UnitMeasurementId",
                table: "ProductsProfile",
                column: "UnitMeasurementId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsProfile_BarCode_DtDeleted",
                table: "ProductsProfile",
                columns: new[] { "BarCode", "DtDeleted" },
                unique: true,
                filter: "[DtDeleted] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasePayments_PaymentMethodsId",
                table: "PurchasePayments",
                column: "PaymentMethodsId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasePayments_PurchasesId",
                table: "PurchasePayments",
                column: "PurchasesId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_PaymentStatusId",
                table: "Purchases",
                column: "PaymentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_PeopleId",
                table: "Purchases",
                column: "PeopleId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasesItems_ProductsProfileId",
                table: "PurchasesItems",
                column: "ProductsProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasesItems_PurchasesId",
                table: "PurchasesItems",
                column: "PurchasesId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_PaymentStatusId",
                table: "Sales",
                column: "PaymentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_PeopleId",
                table: "Sales",
                column: "PeopleId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesItems_ProductsProfileId",
                table: "SalesItems",
                column: "ProductsProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesItems_SalesId",
                table: "SalesItems",
                column: "SalesId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesPayment_PaymentMethodsId",
                table: "SalesPayment",
                column: "PaymentMethodsId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesPayment_SalesId",
                table: "SalesPayment",
                column: "SalesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankAccount");

            migrationBuilder.DropTable(
                name: "Losses");

            migrationBuilder.DropTable(
                name: "ProductsPrices");

            migrationBuilder.DropTable(
                name: "PurchasePayments");

            migrationBuilder.DropTable(
                name: "PurchasesItems");

            migrationBuilder.DropTable(
                name: "SalesItems");

            migrationBuilder.DropTable(
                name: "SalesPayment");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "BankAgency");

            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "ProductsProfile");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Bank");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "UnitMeasurement");

            migrationBuilder.DropTable(
                name: "PaymentStatus");

            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
