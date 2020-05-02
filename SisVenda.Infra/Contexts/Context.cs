using Microsoft.EntityFrameworkCore;
using SisVenda.Domain.Entities;
using SisVenda.Infra.Maps;

namespace SisVenda.Infra.Contexts
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new ComprasMap());
            //modelBuilder.ApplyConfiguration(new FormasPagtoMap());
            //modelBuilder.ApplyConfiguration(new ItensCompraMap());
            //modelBuilder.ApplyConfiguration(new ItensVendaMap());
            modelBuilder.ApplyConfiguration(new PercasMap());
            //modelBuilder.ApplyConfiguration(new PessoasMap());
            modelBuilder.ApplyConfiguration(new PrecosProdutoMap());
            modelBuilder.ApplyConfiguration(new UsuariosMap());
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
        public DbSet<ProductPrices> ProductPrices { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<UnitMeasurement> UnitMeasurement { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
