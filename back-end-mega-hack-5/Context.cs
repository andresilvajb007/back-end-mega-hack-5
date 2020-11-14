using System;
using back_end_mega_hack_5.Entidades;
using Microsoft.EntityFrameworkCore;

namespace back_end_mega_hack_5
{
    public class Context : DbContext
    {
        public Context(DbContextOptions dbContextOptions)
            :base(dbContextOptions)
        {
            this.ChangeTracker.AutoDetectChangesEnabled = false;
        }


        public DbSet<Boleto> Boleto { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<ContaCorrente> ContaCorrente { get; set; }
        public DbSet<Lembrete> Lembrete { get; set; }
        public DbSet<TipoBoleto> TipoBoleto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Boleto>(x=>
            {
                x.HasKey(o => o.Id);
                x.HasOne(o => o.TipoBoleto)
                    .WithMany(t => t.Boletos)
                    .OnDelete(DeleteBehavior.Cascade);                
            });

            modelBuilder.Entity<Cliente>(x =>
            {
                x.HasKey(o => o.Id);
                x.HasOne(o => o.ContaCorrente)
                    .WithOne(c => c.Cliente)
                    .HasForeignKey<ContaCorrente>(c => c.ClienteId);
            });

            modelBuilder.Entity<ContaCorrente>(x =>
            {
                x.HasKey(o => o.Id);                
            });

            modelBuilder.Entity<Lembrete>(x =>
            {
                x.HasKey(o => o.Id);
            });

            modelBuilder.Entity<TipoBoleto>(x =>
            {
                x.HasKey(o => o.Id);
            });

        }


    }
}
