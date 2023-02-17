using System.ComponentModel.DataAnnotations;

namespace GroupProject.Models
{
    public class Merch
    {
        [Key]
        public String itemName { get; set; }
        public String itemDescription { get; set; }
        public int itemInStock { get; set; }
        public double itemPrice { get; set; }


    }
}
