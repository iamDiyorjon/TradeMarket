using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Data
{
    public class TradeMarketDbContext : DbContext
    {
        public TradeMarketDbContext()
        { }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(
        //        @"Server=(localdb)\mssqllocaldb;Database=TradeMarket;Trusted_Connection=True;");
        //}
        public TradeMarketDbContext(DbContextOptions<TradeMarketDbContext> options) 
            : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<ReceiptDetail> ReceiptsDetails { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Receipt>()
                 .HasOne(rec => rec.Customer)
                 .WithMany(cus => cus.Receipts)
                 .HasForeignKey(rec => rec.CustomerId);

            modelBuilder.Entity<Customer>()
                .HasOne(rec => rec.Person)
                .WithOne();

            modelBuilder.Entity<ReceiptDetail>()
                .HasOne(rec => rec.Receipt)
                .WithMany(det => det.ReceiptDetails)
                .HasForeignKey(rec => rec.ReceiptId);

            modelBuilder.Entity<ReceiptDetail>()
                .HasOne(rec=>rec.Product)
                .WithMany(pro=>pro.ReceiptDetails)
                .HasForeignKey(rec=>rec.ProductId);

            modelBuilder.Entity<Product>()
                .HasOne(pro => pro.Category)
                .WithMany(cat => cat.Products)
                .HasForeignKey(pro => pro.ProductCategoryId);
                
        }

    }
}
