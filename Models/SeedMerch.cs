using GroupProject.Models;
using Microsoft.EntityFrameworkCore;

namespace groupproject.Models
{
    public class SeedMerch
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MerchContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MerchContext>>()))
            {
                // Look for any movies.
                if (context.Merchy.Any())
                {
                    return;   // DB has been seeded
                }

                context.Merchy.AddRange(
                    new Merch
                    {
                        itemName = "Hat",
                        itemDescription = "This is a hat.",
                        itemInStock = 50,
                        itemPrice = 19.99

                    },
                    new Merch
                    {
                        itemName = "Action Figure",
                        itemDescription = "This is a Action Figure.",
                        itemInStock = 5,
                        itemPrice = 299.75

                    },
                    new Merch
                    {
                        itemName = "Xbox Controller",
                        itemDescription = "This is a Xbox Controller.",
                        itemInStock = 2,
                        itemPrice = 60.00

                    }


                );
                context.SaveChanges();
            }
        }
    }
}
