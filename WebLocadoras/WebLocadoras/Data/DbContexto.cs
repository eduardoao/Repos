using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WebLocadoras.Models;


namespace WebLocadoras.Data
{
    public class DbContexto : DbContext
    {       

        public DbContexto(DbContextOptions<DbContexto> options) : base(options)
        {        

        }
     

        public DbSet<EntidadeCliente> DataCliente { get; set; }

        public DbSet<EntidadeFilme> DataFilme { get; set; }

        public DbSet<EntidadeLocacao> DataLocacao { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<EntidadeCliente>().HasKey(m => m.Id);
            builder.Entity<EntidadeFilme>().HasKey(m => m.Id);


            // shadow properties
            builder.Entity<EntidadeCliente>().Property<DateTime>("UpdatedTimestamp");
            builder.Entity<EntidadeFilme>().Property<DateTime>("UpdatedTimestamp");

            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            updateUpdatedProperty<EntidadeCliente>();
            updateUpdatedProperty<EntidadeFilme>();

            return base.SaveChanges();
        }

        private void updateUpdatedProperty<T>() where T : class
        {
            var modifiedSourceInfo =
                ChangeTracker.Entries<T>()
                    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entry in modifiedSourceInfo)
            {
                entry.Property("UpdatedTimestamp").CurrentValue = DateTime.UtcNow;
            }
        }
    }
}
