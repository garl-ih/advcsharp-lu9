using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using groupproject.Models;

namespace groupproject.Data
{
    public class GameContext : DbContext
    {
        public GameContext(DbContextOptions<GameContext> options)
            : base(options)
        {
        }
        public DbSet<groupproject.Models.Game> Game { get; set; } = default!;
    }
}
