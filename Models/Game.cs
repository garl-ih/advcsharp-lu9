using System.ComponentModel.DataAnnotations;

namespace groupproject.Models
{
    public class Game
    {
        public String name { get; set; }
        public double price { get; set; }
        public double revenue { get; set; }
        public int numberOfPlayers { get; set; }
        public String platforms { get; set; }

        [DataType(DataType.Date)]
        public DateTime releaseDate { get; set; }
    }

    

}
