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
            //modelBuilder.Entity<Products>().HasOne(x => x.UnitMeasurement).WithMany<UnitMeasurement>(x => x.Products).HasForeignKey(x => x.IdUnitMeasurement);
            //modelBuilder.ApplyConfiguration(new ComprasMap());
            //modelBuilder.ApplyConfiguration(new FormasPagtoMap());
            //modelBuilder.ApplyConfiguration(new ItensCompraMap());
            //modelBuilder.ApplyConfiguration(new ItensVendaMap());
            modelBuilder.ApplyConfiguration(new LossesMap());
            //modelBuilder.ApplyConfiguration(new PessoasMap());
            modelBuilder.ApplyConfiguration(new ProductPricesMap());
            modelBuilder.ApplyConfiguration(new UsersMap());
            modelBuilder.ApplyConfiguration(new ProductsMap());
            //modelBuilder.ApplyConfiguration(new UndsMedidaMap());
            //modelBuilder.ApplyConfiguration(new VendasMap());
        }

        public DbSet<People> People { get; set; }
        public DbSet<Purchases> Purchases { get; set; }
        public DbSet<PurchasesItems> PurchasesItems { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<SalesItems> SalesItems { get; set; }
        public DbSet<PaymentMethods> PaymentMethods { get; set; }
        public DbSet<Losses> Losses { get; set; }
        public DbSet<ProductsPrices> ProductPrices { get; set; }
        public DbSet<Products> Product { get; set; }
        public DbSet<UnitMeasurement> UnitMeasurement { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<SalesPayment> SalesPayment { get; set; }
        public DbSet<PurchasesPayments> PurchasePayments { get; set; }
        public DbSet<PaymentStatus> PaymentStatus { get; set; }
    }
}
