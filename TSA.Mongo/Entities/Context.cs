using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TSA.Mongo.Entities
{
    public class Context : DbContext
    {
        public Context()
        {
            //this.Configuration.AutoDetectChangesEnabled = false;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=TANIA-DELL;Database=PraticSoftware;user id=sa; password=SYSTEM_AGILI;", options => options.MaxBatchSize(1000));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PessoaMap());
            modelBuilder.ApplyConfiguration(new TelefoneMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
