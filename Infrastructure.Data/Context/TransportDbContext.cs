using Infrastructure.Data.Models;
using Infrastructure.Data.Models.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Infrastructure.Data.Context
{
    public class TransportDbContext: DbContext
    {
        private IHttpContextAccessor _httpContextAccessor;
        public TransportDbContext(DbContextOptions<TransportDbContext>options, IHttpContextAccessor httpContextAccessor) : base(options) 
        {
            _httpContextAccessor = httpContextAccessor;
        }
        
        public DbSet<Transport> Transports { get; set; }
        public override int SaveChanges()
        {
            // Get all the entities that inherit from AuditableEntity
            // and have a state of Added or Modified
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is AuditableBaseEntity && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            // For each entity we will set the Audit properties
            foreach (var entityEntry in entries)
            {
                // If the entity state is Added let's set
                // the CreatedAt and CreatedBy properties
                if (entityEntry.State == EntityState.Added)
                {
                    ((AuditableBaseEntity)entityEntry.Entity).CreatedOn = DateTime.UtcNow;
                    ((AuditableBaseEntity)entityEntry.Entity).CreatedBy = this._httpContextAccessor?.HttpContext?.User?.Identity?.Name ?? "MyApp";
                }
                else
                {
                    // If the state is Modified then we don't want
                    // to modify the CreatedAt and CreatedBy properties
                    // so we set their state as IsModified to false
                    Entry((AuditableBaseEntity)entityEntry.Entity).Property(p => p.CreatedOn).IsModified = false;
                    Entry((AuditableBaseEntity)entityEntry.Entity).Property(p => p.CreatedBy).IsModified = false;
                }

                // In any case we always want to set the properties
                // ModifiedAt and ModifiedBy
                ((AuditableBaseEntity)entityEntry.Entity).LastModifedOn = DateTime.UtcNow;
                ((AuditableBaseEntity)entityEntry.Entity).LastModifedBy = this._httpContextAccessor?.HttpContext?.User?.Identity?.Name ?? "MyApp";
            }

            // After we set all the needed properties
            // we call the base implementation of SaveChanges
            // to actually save our entities in the database
            return base.SaveChanges();
        }
    }
}
