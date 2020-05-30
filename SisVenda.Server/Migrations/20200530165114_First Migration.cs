using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SisVenda.Server.Migrations
{
    public partial class FirstMigration : Migration
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
                    Description = table.Column<string>(type: "char(150)", nullable: true)
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
                    Name = table.Column<string>(type: "char(150)", nullable: true),
                    Contact = table.Column<string>(type: "char(150)", nullable: true),
                    CPF = table.Column<string>(type: "char(11)", nullable: true),
                    CNPJ = table.Column<string>(type: "char(14)", nullable: true),
                    Street = table.Column<string>(type: "char(100)", nullable: true),
                    Number = table.Column<string>(type: "char(10)", nullable: true),
                    Neighborhood = table.Column<string>(type: "char(30)", nullable: true),
                    City = table.Column<string>(type: "char(50)", nullable: true),
                    State = table.Column<string>(type: "char(2)", nullable: true),
                    ZipCode = table.Column<string>(type: "char(10)", nullable: true),
                    AdressEmail = table.Column<string>(type: "char(50)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "char(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
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
                    BankId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAgency", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankAgency_Bank_BankId",
                        column: x => x.BankId,
                        principalTable: "Bank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(32)", nullable: false),
                    DtDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    DtRegister = table.Column<DateTime>(type: "datetime", nullable: false),
                    Name = table.Column<string>(type: "varchar(150)", nullable: true),
                    Description = table.Column<string>(type: "varchar(150)", nullable: true),
                    UnitMeasurementId = table.Column<string>(nullable: true),
                    QtdStock = table.Column<decimal>(type: "decimal(10, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_UnitMeasurement_UnitMeasurementId",
                        column: x => x.UnitMeasurementId,
                        principalTable: "UnitMeasurement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BankAccount",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(32)", nullable: false),
                    DtDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    DtRegister = table.Column<DateTime>(type: "datetime", nullable: false),
                    Account = table.Column<string>(type: "char(25)", nullable: true),
                    BankAgencyId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankAccount_BankAgency_BankAgencyId",
                        column: x => x.BankAgencyId,
                        principalTable: "BankAgency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    PurchasesId = table.Column<string>(nullable: true)
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
                        onDelete: ReferentialAction.Restrict);
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
                    SalesId = table.Column<string>(nullable: true)
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Losses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(32)", nullable: false),
                    DtDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    DtRegister = table.Column<DateTime>(type: "datetime", nullable: false),
                    ProductId = table.Column<string>(nullable: false),
                    DtMoviment = table.Column<DateTime>(type: "datetime", nullable: false),
                    Description = table.Column<string>(type: "varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Losses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Losses_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductPrices",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(32)", nullable: false),
                    DtDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    DtRegister = table.Column<DateTime>(type: "datetime", nullable: false),
                    ProductId = table.Column<string>(nullable: true),
                    DtEffective = table.Column<DateTime>(type: "datetime", nullable: false),
                    SalesCost = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    SalesPrice = table.Column<decimal>(type: "decimal(10, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductPrices_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchasesItems",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(32)", nullable: false),
                    DtDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    DtRegister = table.Column<DateTime>(type: "datetime", nullable: false),
                    ProductsId = table.Column<string>(nullable: false),
                    QuantityItem = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    CostPrice = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    PurchasesId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasesItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchasesItems_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchasesItems_Purchases_PurchasesId",
                        column: x => x.PurchasesId,
                        principalTable: "Purchases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesItems",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(32)", nullable: false),
                    DtDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    DtRegister = table.Column<DateTime>(type: "datetime", nullable: false),
                    ProductsId = table.Column<string>(nullable: false),
                    QuantityItem = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    CostPrice = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    SalesId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesItems_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesItems_Sales_SalesId",
                        column: x => x.SalesId,
                        principalTable: "Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DtDeleted", "DtRegister", "Name", "Password", "User" },
                values: new object[] { "fa0ce6d927ee4bf081dc338ad045de40", null, new DateTime(2020, 5, 30, 13, 51, 14, 480, DateTimeKind.Local).AddTicks(3110), "Administrador", "123", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_BankAccount_BankAgencyId",
                table: "BankAccount",
                column: "BankAgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAgency_BankId",
                table: "BankAgency",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Losses_ProductId",
                table: "Losses",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPrices_ProductId",
                table: "ProductPrices",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UnitMeasurementId",
                table: "Products",
                column: "UnitMeasurementId");

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
                name: "IX_PurchasesItems_ProductsId",
                table: "PurchasesItems",
                column: "ProductsId");

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
                name: "IX_SalesItems_ProductsId",
                table: "SalesItems",
                column: "ProductsId");

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
                name: "ProductPrices");

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
                name: "Products");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Bank");

            migrationBuilder.DropTable(
                name: "UnitMeasurement");

            migrationBuilder.DropTable(
                name: "PaymentStatus");

            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
