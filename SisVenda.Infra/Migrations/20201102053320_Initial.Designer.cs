﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SisVenda.Infra.Contexts;

namespace SisVenda.Infra.Migrations
{
    [DbContext(typeof(SisVendaContext))]
    [Migration("20201102053320_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SisVenda.Domain.Entities.Bank", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(32)");

                    b.Property<string>("Code")
                        .HasColumnType("char(10)");

                    b.Property<DateTime?>("DtDeleted")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DtRegister")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .HasColumnType("char(150)");

                    b.HasKey("Id");

                    b.ToTable("Bank");
                });

            modelBuilder.Entity("SisVenda.Domain.Entities.BankAccount", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(32)");

                    b.Property<string>("Account")
                        .HasColumnType("char(25)");

                    b.Property<string>("BankAgencyId")
                        .IsRequired()
                        .HasColumnType("varchar(32)");

                    b.Property<DateTime?>("DtDeleted")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DtRegister")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("BankAgencyId");

                    b.ToTable("BankAccount");
                });

            modelBuilder.Entity("SisVenda.Domain.Entities.BankAgency", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(32)");

                    b.Property<string>("BankId")
                        .IsRequired()
                        .HasColumnType("varchar(32)");

                    b.Property<string>("Code")
                        .HasColumnType("char(10)");

                    b.Property<DateTime?>("DtDeleted")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DtRegister")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .HasColumnType("char(150)");

                    b.HasKey("Id");

                    b.HasIndex("BankId");

                    b.ToTable("BankAgency");
                });

            modelBuilder.Entity("SisVenda.Domain.Entities.Losses", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(32)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<DateTime?>("DtDeleted")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DtMoviment")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DtRegister")
                        .HasColumnType("datetime");

                    b.Property<string>("ProductsProfileId")
                        .IsRequired()
                        .HasColumnType("varchar(32)");

                    b.HasKey("Id");

                    b.HasIndex("ProductsProfileId");

                    b.ToTable("Losses");
                });

            modelBuilder.Entity("SisVenda.Domain.Entities.PaymentMethods", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(32)");

                    b.Property<DateTime?>("DtDeleted")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DtRegister")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("char(150)");

                    b.HasKey("Id");

                    b.ToTable("PaymentMethods");
                });

            modelBuilder.Entity("SisVenda.Domain.Entities.PaymentStatus", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(32)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("char(150)");

                    b.Property<DateTime?>("DtDeleted")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DtRegister")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("PaymentStatus");
                });

            modelBuilder.Entity("SisVenda.Domain.Entities.People", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(32)");

                    b.Property<string>("AdressEmail")
                        .IsRequired()
                        .HasColumnType("char(50)");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("char(14)");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("char(11)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("char(50)");

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasColumnType("char(150)");

                    b.Property<DateTime?>("DtDeleted")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DtRegister")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsCustomer")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSupplier")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("char(150)");

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .HasColumnType("char(30)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("char(10)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("char(11)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("char(2)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("char(100)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("char(10)");

                    b.HasKey("Id");

                    b.ToTable("People");
                });

            modelBuilder.Entity("SisVenda.Domain.Entities.Products", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(32)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<DateTime?>("DtDeleted")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DtRegister")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<decimal>("QuantityStock")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("SisVenda.Domain.Entities.ProductsPrices", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(32)");

                    b.Property<decimal>("AveragePurchaseCost")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<DateTime?>("DtDeleted")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DtEffective")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DtRegister")
                        .HasColumnType("datetime");

                    b.Property<string>("ProductsProfileId")
                        .IsRequired()
                        .HasColumnType("varchar(32)");

                    b.Property<decimal>("SalesPrice")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("Id");

                    b.HasIndex("ProductsProfileId");

                    b.ToTable("ProductsPrices");
                });

            modelBuilder.Entity("SisVenda.Domain.Entities.ProductsProfile", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(32)");

                    b.Property<string>("BarCode")
                        .IsRequired()
                        .HasColumnType("char(100)");

                    b.Property<DateTime?>("DtDeleted")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DtRegister")
                        .HasColumnType("datetime");

                    b.Property<string>("ProductsId")
                        .IsRequired()
                        .HasColumnType("varchar(32)");

                    b.Property<string>("UnitMeasurementId")
                        .IsRequired()
                        .HasColumnType("varchar(32)");

                    b.HasKey("Id");

                    b.HasIndex("ProductsId");

                    b.HasIndex("UnitMeasurementId");

                    b.HasIndex("BarCode", "DtDeleted")
                        .IsUnique()
                        .HasFilter("[DtDeleted] IS NOT NULL");

                    b.ToTable("ProductsProfile");
                });

            modelBuilder.Entity("SisVenda.Domain.Entities.Purchases", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(32)");

                    b.Property<decimal>("AmountAddition")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<decimal>("AmountDiscount")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<DateTime?>("DtDeleted")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DtMoviment")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DtRegister")
                        .HasColumnType("datetime");

                    b.Property<string>("PaymentStatusId")
                        .IsRequired()
                        .HasColumnType("varchar(32)");

                    b.Property<string>("PeopleId")
                        .IsRequired()
                        .HasColumnType("varchar(32)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("Id");

                    b.HasIndex("PaymentStatusId");

                    b.HasIndex("PeopleId");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("SisVenda.Domain.Entities.PurchasesItems", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(32)");

                    b.Property<decimal>("CostPrice")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<DateTime?>("DtDeleted")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DtRegister")
                        .HasColumnType("datetime");

                    b.Property<string>("ProductsProfileId")
                        .IsRequired()
                        .HasColumnType("varchar(32)");

                    b.Property<string>("PurchasesId")
                        .IsRequired()
                        .HasColumnType("varchar(32)");

                    b.Property<decimal>("QuantityItem")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<decimal>("SalePrice")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("Id");

                    b.HasIndex("ProductsProfileId");

                    b.HasIndex("PurchasesId");

                    b.ToTable("PurchasesItems");
                });

            modelBuilder.Entity("SisVenda.Domain.Entities.PurchasesPayments", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(32)");

                    b.Property<DateTime?>("DtDeleted")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DtPayment")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DtPaymentForecast")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DtRegister")
                        .HasColumnType("datetime");

                    b.Property<string>("PaymentMethodsId")
                        .IsRequired()
                        .HasColumnType("varchar(32)");

                    b.Property<string>("PurchasesId")
                        .IsRequired()
                        .HasColumnType("varchar(32)");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("Id");

                    b.HasIndex("PaymentMethodsId");

                    b.HasIndex("PurchasesId");

                    b.ToTable("PurchasePayments");
                });

            modelBuilder.Entity("SisVenda.Domain.Entities.Sales", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(32)");

                    b.Property<decimal>("AmountAddition")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<decimal>("AmountDiscount")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<DateTime?>("DtDeleted")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DtMoviment")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DtRegister")
                        .HasColumnType("datetime");

                    b.Property<string>("PaymentStatusId")
                        .IsRequired()
                        .HasColumnType("varchar(32)");

                    b.Property<string>("PeopleId")
                        .IsRequired()
                        .HasColumnType("varchar(32)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("Id");

                    b.HasIndex("PaymentStatusId");

                    b.HasIndex("PeopleId");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("SisVenda.Domain.Entities.SalesItems", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(32)");

                    b.Property<decimal>("CostPrice")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<DateTime?>("DtDeleted")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DtRegister")
                        .HasColumnType("datetime");

                    b.Property<string>("ProductsProfileId")
                        .IsRequired()
                        .HasColumnType("varchar(32)");

                    b.Property<decimal>("QuantityItem")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<decimal>("SalePrice")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("SalesId")
                        .IsRequired()
                        .HasColumnType("varchar(32)");

                    b.HasKey("Id");

                    b.HasIndex("ProductsProfileId");

                    b.HasIndex("SalesId");

                    b.ToTable("SalesItems");
                });

            modelBuilder.Entity("SisVenda.Domain.Entities.SalesPayment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(32)");

                    b.Property<DateTime?>("DtDeleted")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DtPayment")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DtPaymentForecast")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DtRegister")
                        .HasColumnType("datetime");

                    b.Property<string>("PaymentMethodsId")
                        .IsRequired()
                        .HasColumnType("varchar(32)");

                    b.Property<string>("SalesId")
                        .IsRequired()
                        .HasColumnType("varchar(32)");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("Id");

                    b.HasIndex("PaymentMethodsId");

                    b.HasIndex("SalesId");

                    b.ToTable("SalesPayment");
                });

            modelBuilder.Entity("SisVenda.Domain.Entities.UnitMeasurement", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(32)");

                    b.Property<DateTime?>("DtDeleted")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DtRegister")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<decimal>("QuantityLosses")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("Id");

                    b.ToTable("UnitMeasurement");
                });

            modelBuilder.Entity("SisVenda.Domain.Entities.Users", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(32)");

                    b.Property<DateTime?>("DtDeleted")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DtRegister")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("char(150)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("char(20)");

                    b.Property<string>("User")
                        .IsRequired()
                        .HasColumnType("char(20)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = "9dee9fc7470a471aa7f2497c304eb96c",
                            DtRegister = new DateTime(2020, 11, 1, 21, 33, 19, 683, DateTimeKind.Local).AddTicks(1248),
                            Name = "Administrador",
                            Password = "123",
                            User = "admin"
                        });
                });

            modelBuilder.Entity("SisVenda.Domain.Entities.BankAccount", b =>
                {
                    b.HasOne("SisVenda.Domain.Entities.BankAgency", null)
                        .WithMany("BankAccount")
                        .HasForeignKey("BankAgencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SisVenda.Domain.Entities.BankAgency", b =>
                {
                    b.HasOne("SisVenda.Domain.Entities.Bank", null)
                        .WithMany("BankAgency")
                        .HasForeignKey("BankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SisVenda.Domain.Entities.Losses", b =>
                {
                    b.HasOne("SisVenda.Domain.Entities.ProductsProfile", null)
                        .WithMany("Losses")
                        .HasForeignKey("ProductsProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SisVenda.Domain.Entities.ProductsPrices", b =>
                {
                    b.HasOne("SisVenda.Domain.Entities.ProductsProfile", null)
                        .WithMany("ProductsPrices")
                        .HasForeignKey("ProductsProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SisVenda.Domain.Entities.ProductsProfile", b =>
                {
                    b.HasOne("SisVenda.Domain.Entities.Products", null)
                        .WithMany("ProductsProfile")
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SisVenda.Domain.Entities.UnitMeasurement", null)
                        .WithMany("ProductsProfile")
                        .HasForeignKey("UnitMeasurementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SisVenda.Domain.Entities.Purchases", b =>
                {
                    b.HasOne("SisVenda.Domain.Entities.PaymentStatus", "PaymentStatus")
                        .WithMany()
                        .HasForeignKey("PaymentStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SisVenda.Domain.Entities.People", null)
                        .WithMany("Purchases")
                        .HasForeignKey("PeopleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SisVenda.Domain.Entities.PurchasesItems", b =>
                {
                    b.HasOne("SisVenda.Domain.Entities.ProductsProfile", null)
                        .WithMany("PurchasesItems")
                        .HasForeignKey("ProductsProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SisVenda.Domain.Entities.Purchases", null)
                        .WithMany("PurchasesItems")
                        .HasForeignKey("PurchasesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SisVenda.Domain.Entities.PurchasesPayments", b =>
                {
                    b.HasOne("SisVenda.Domain.Entities.PaymentMethods", null)
                        .WithMany("PurchasesPayments")
                        .HasForeignKey("PaymentMethodsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SisVenda.Domain.Entities.Purchases", null)
                        .WithMany("PurchasePayments")
                        .HasForeignKey("PurchasesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SisVenda.Domain.Entities.Sales", b =>
                {
                    b.HasOne("SisVenda.Domain.Entities.PaymentStatus", "PaymentStatus")
                        .WithMany()
                        .HasForeignKey("PaymentStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SisVenda.Domain.Entities.People", null)
                        .WithMany("Sales")
                        .HasForeignKey("PeopleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SisVenda.Domain.Entities.SalesItems", b =>
                {
                    b.HasOne("SisVenda.Domain.Entities.ProductsProfile", null)
                        .WithMany("SalesItems")
                        .HasForeignKey("ProductsProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SisVenda.Domain.Entities.Sales", null)
                        .WithMany("SalesItems")
                        .HasForeignKey("SalesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SisVenda.Domain.Entities.SalesPayment", b =>
                {
                    b.HasOne("SisVenda.Domain.Entities.PaymentMethods", null)
                        .WithMany("SalesPayment")
                        .HasForeignKey("PaymentMethodsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SisVenda.Domain.Entities.Sales", null)
                        .WithMany("SalesPayment")
                        .HasForeignKey("SalesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
