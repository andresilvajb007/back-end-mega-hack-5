using System;
using Microsoft.EntityFrameworkCore;

namespace back_end_mega_hack_5
{
    public class Context : DbContext
    {
        public Context(DbContextOptions dbContextOptions)
            :base(dbContextOptions)
        {
        }


        //public DbSet<Incentivador> Incentivador { get; set; }        

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Incentivador>(ConfigureIncentivador);
 
        //}

        //private void ConfigurePagamentoIncentivadorPIX(EntityTypeBuilder<PagamentoIncentivadorPIX> obj)
        //{
        //    obj.HasKey(x => x.Id);

     
        //}

    }
}
