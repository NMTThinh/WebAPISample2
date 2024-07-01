using Microsoft.EntityFrameworkCore;
using WebAPISample2.Entities;

namespace WebAPISample2.EF
{
    public class SampleDbContext : DbContext
    {
        public SampleDbContext(DbContextOptions<SampleDbContext> options) : base(options)
        {
        }

        public DbSet<Sample> Samples { get; set; }
    }
}