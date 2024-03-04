using Core.Persistence.Repositories;
using Core.Security.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Persistence.Context
{
    public class WMS_DbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Carton> Cartons { get; set; }
        public DbSet<OperationType> OperationTypes { get; set; }
        public DbSet<Pallet> Pallets { get; set; }
        public DbSet<PalletMovement> PalletMovements { get; set; }
        public DbSet<PalletStatus> PalletStatuses { get; set; }
        public DbSet<PalletType> PalletTypes { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<EmailAuthenticator> EmailAuthenticator { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<OtpAuthenticator> OtpAuthenticators { get; set; }
        public DbSet<WarehouseReceipt> WarehouseReceipts { get; set; }
        public DbSet<WarehouseReceiptItem> WarehouseReceiptItems { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            IEnumerable<EntityEntry<Entity>> entities = ChangeTracker.Entries<Entity>().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted);

            foreach (var entity in entities)
            {
                switch (entity.State)
                {
                    case EntityState.Deleted:
                        entity.State = EntityState.Modified;
                        entity.Entity.DeletedAt = DateTime.Now;
                        entity.Entity.IsActive = false;
                        break;

                    case EntityState.Modified:
                        entity.Entity.UpdatedAt = DateTime.Now;
                        break;

                    case EntityState.Added:
                        entity.Entity.IsActive = true;
                        entity.Entity.CreatedAt = DateTime.Now;
                        break;

                    default:
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}