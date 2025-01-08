using Microsoft.EntityFrameworkCore;
using InvoiceManagement.Models;

namespace InvoiceManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InvoiceItem>()
                .HasOne<Invoice>()
                .WithMany(i => i.InvoiceItems)
                .HasForeignKey(ii => ii.InvoiceId);

            modelBuilder.Entity<Invoice>()
                .Property(i => i.Status)
                .HasConversion<string>();

            modelBuilder.Entity<Invoice>()
                .Property(i => i.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Invoice>()
                .Property(i => i.UpdatedAt)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
