using Microsoft.EntityFrameworkCore;
using SisVenda.Domain.Entities;
using SisVenda.Infra.Maps;

namespace SisVenda.Infra.Contexts
{
    public class SisVendaContext : DbContext
    {
        public SisVendaContext(DbContextOptions<SisVendaContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsersMap());
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<PaymentStatus> PaymentStatus { get; set; }
        public DbSet<Bank> Bank { get; set; }
        public DbSet<BankAgency> BankAgency { get; set; }
        public DbSet<BankAccount> BankAccount { get; set; }
        public DbSet<People> People { get; set; }
        public DbSet<UnitMeasurement> UnitMeasurement { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<ProductsProfile> ProductsProfile { get; set; }
        public DbSet<ProductsPrices> ProductPrices { get; set; }
        public DbSet<Purchases> Purchases { get; set; }
        public DbSet<PurchasesItems> PurchasesItems { get; set; }
        public DbSet<PurchasesPayments> PurchasePayments { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<SalesItems> SalesItems { get; set; }
        public DbSet<SalesPayment> SalesPayment { get; set; }
        public DbSet<PaymentMethods> PaymentMethods { get; set; }
        public DbSet<Losses> Losses { get; set; }
    }
}
