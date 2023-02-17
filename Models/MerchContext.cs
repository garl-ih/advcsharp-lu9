using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace GroupProject.Models
{
    public class MerchContext : DbContext
    {
        public MerchContext(DbContextOptions<MerchContext> options)
            : base(options)
        {
        }

        public DbSet<Merch> Merchy { get; set; } = null!;
    }
}