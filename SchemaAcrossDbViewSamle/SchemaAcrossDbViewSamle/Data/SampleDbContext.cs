using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchemaAcrossDbViewSamle.Data.Entities;

namespace SchemaAcrossDbViewSamle.Data
{
    public class SampleDbContext: DbContext
    {
        public const string DefaultConnectionStringName = "sampledb";

        public SampleDbContext(DbContextOptions<SampleDbContext> options) : base(options)
        {
        }
        public DbSet<Test1> Test1 { get; set; }
        public virtual DbQuery<QueryTest2> QueryTest2 { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Query<QueryTest2>(entity =>
            {
                entity.ToView("v_seconddb_test2");
            });

            modelBuilder.Entity<Test1>(entity =>
            {
                entity.HasData(new List<Test1>
                {
                    new Test1 { Id = "test1-1", Name = "test1", QueryTest2Id = "test2-1"}
                });
            });
        }
    }
}
