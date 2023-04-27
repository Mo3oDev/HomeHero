using System.ComponentModel.DataAnnotations;

namespace HomeHero.Models
{
    public class Location
    {
        [Key]
        public int locationID { get; set; }
        public string city { get; set; }
        public string address { get; set; }

    }
}
