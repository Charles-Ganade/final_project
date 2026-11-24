using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using final_project.Models;
using final_project.Models.Enums;

namespace final_project.Data
{
    public class ApplicationDbContext : IdentityDbContext<Account>
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        public DbSet<Customer> Customers => Set<Customer>();

        public DbSet<Store> Stores => Set<Store>();

        public DbSet<Category> Categories => Set<Category>();

        public DbSet<StoreCategory> StoreCategories => Set<StoreCategory>();

        protected override void OnModelCreating(
            ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Account>(entity =>
            {
                entity.Property(a => a.CreatedAt)
                    .HasDefaultValueSql("SYSUTCDATETIME()");

                entity.HasIndex(a => a.NormalizedEmail)
                    .IsUnique()
                    .HasDatabaseName("IX_AspNetUsers_NormalizedEmail");
            });

            builder.Entity<Customer>(entity =>
            {
                entity.HasKey(c => c.AccountId);

                entity.Property(c => c.DisplayName)
                    .HasMaxLength(100)
                    .IsRequired();

                entity.HasOne(c => c.Account)
                    .WithOne(a => a.Customer)
                    .HasForeignKey<Customer>(c => c.AccountId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Store>(entity =>
            {
                entity.HasKey(s => s.AccountId);

                entity.Property(s => s.Name)
                    .HasMaxLength(150)
                    .IsRequired();

                entity.Property(s => s.Description)
                    .HasColumnType("nvarchar(max)");

                entity.Property(s => s.CoverImageUrl)
                    .HasMaxLength(500);

                entity.Property(s => s.ApprovalStatus)
                    .HasConversion<int>()
                    .HasDefaultValue(StoreApprovalStatus.Pending);

                entity.Property(s => s.RejectionReason)
                    .HasMaxLength(500);

                entity.HasOne(s => s.Account)
                    .WithOne(a => a.Store)
                    .HasForeignKey<Store>(s => s.AccountId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(s => s.ReviewedBy)
                    .WithMany()
                    .HasForeignKey(s => s.ReviewedByAccountId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<Category>(entity =>
            {
                entity.HasKey(c => c.Id);

                entity.Property(c => c.Name)
                    .HasMaxLength(100)
                    .IsRequired();

                entity.HasIndex(c => c.Name)
                    .IsUnique();
            });

            builder.Entity<StoreCategory>(entity =>
            {
                entity.HasKey(sc => new { sc.StoreId, sc.CategoryId });

                entity.HasOne(sc => sc.Store)
                    .WithMany(s => s.StoreCategories)
                    .HasForeignKey(sc => sc.StoreId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(sc => sc.Category)
                    .WithMany(c => c.StoreCategories)
                    .HasForeignKey(sc => sc.CategoryId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasIndex(sc => sc.CategoryId);
            });
        }
    }
}