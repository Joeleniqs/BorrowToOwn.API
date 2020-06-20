using System;
using BorrowToOwn.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BorrowToOwn.Data.Data
{
    public class BorrowContext : IdentityDbContext<AppUser>
    {
        private readonly IConfiguration _config;
       // private readonly ILoggerFactory _loggerFactory;


        public BorrowContext(DbContextOptions<BorrowContext> options,IConfiguration configuration/*,ILoggerFactory loggerFactory*/) : base(options)
        {
            _config = configuration ?? throw new ArgumentNullException(nameof(configuration));
            //_loggerFactory = loggerFactory;
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseLoggerFactory(_loggerFactory)  //tie-up DbContext with LoggerFactory object
        //    .EnableSensitiveDataLogging();
        //   // optionsBuilder.UseNpgsql(_config["ConnectionStrings:BorrowPgConnection"]);
        //}
           

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<Product>()
                .HasIndex(p => p.Name);
            builder.Entity<AppUser>()
                .HasIndex(p => new { p.SurrogateIdentifier })
                .IsUnique();
            builder.Entity<AppUser>()
                .HasIndex(p => new { p.FirstName, p.LastName, p.Email, p.UserName });
            builder.Entity<ProductPaymentPlan>().HasKey(k => new { k.ProductId, k.PaymentPlanId });
            builder.Entity<ProductPaymentPlan>()
                .HasOne(k => k.Product)
                .WithMany(k=>k.AllowedPaymentPlans)
                .HasForeignKey(k=>k.ProductId);
            builder.Entity<ProductPaymentPlan>()
              .HasOne(k => k.PaymentPlan)
              .WithMany(k => k.ProductsAssociatedWith)
                .HasForeignKey(k => k.PaymentPlanId);

        }
        // public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PaymentPlan> PaymentPlans { get; set; }
      //  public DbSet<ProductPaymentPlan> ProductPaymentPlans { get; set; }
        public DbSet<PaymentHistory> PaymentHistories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }

    }
}
