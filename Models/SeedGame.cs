using System;

namespace groupproject.Models
{
    public class SeedGame
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new GameContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<GameContext>>()))
            {
                // Look for any movies.
                if (context.game.Any())
                {
                    return;   // DB has been seeded
                }

                context.game.AddRange(
                    new Game
                    {
                        name = "Halo",
                        releaseDate = DateTime.Parse("2000-01-01"),                        
                        price = 60.00,
                        revenue = 9999.00,
                        numberOfPlayers = 9999999,
                        platforms = "Xbox, PC"

                    },
                     new Game
                     {
                         name = "Halo 2",
                         releaseDate = DateTime.Parse("2002-02-02"),
                         price = 60.00,
                         revenue = 8888.00,
                         numberOfPlayers = 8888,
                         platforms = "Xbox, PC"

                     },
                     new Game
                     {
                         name = "Halo 3",
                         releaseDate = DateTime.Parse("2007-07-07"),
                         price = 60.00,
                         revenue = 7777.00,
                         numberOfPlayers = 7777777,
                         platforms = "Xbox"

                     }


                );
                context.SaveChanges();
            }
        }
    }
}
