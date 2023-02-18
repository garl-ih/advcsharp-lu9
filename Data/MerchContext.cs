using Microsoft.EntityFrameworkCore;

namespace groupproject.Data
{
    public class MerchContext : DbContext
    {
        public MerchContext(DbContextOptions<GameContext> options)
            : base(options)
        {
        }

        public MerchContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<GroupProject.Models.Merch> Merch { get; set; } = default!;
    }
}

