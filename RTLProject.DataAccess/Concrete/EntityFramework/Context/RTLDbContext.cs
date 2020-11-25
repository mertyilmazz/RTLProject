using Microsoft.EntityFrameworkCore;
using RTLProject.Entities.Concrete;

namespace RTL.DataAccess.Concrete.EntityFramework.Context
{
    public class RTLDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=RTL;User Id=sa;Password=test;");
        }

        public DbSet<TvShow> TvShow { get; set; }
        public DbSet<Cast> Cast { get; set; }
        public DbSet<UpdateQueue> UpdateQueue { get; set; }


    }
}
