using System.ComponentModel.DataAnnotations;

namespace GroupProject.Models
{
    public class Merch
    {
        
        public int Id { get; set; }
        public String itemName { get; set; }
        public String itemDescription { get; set; }
        public int itemInStock { get; set; }
        public double itemPrice { get; set; }


    }
}
