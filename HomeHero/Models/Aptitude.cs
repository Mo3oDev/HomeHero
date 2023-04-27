using System.ComponentModel.DataAnnotations;

namespace HomeHero.Models
{
    public class Aptitude
    {
        [Key]
        public int aptitudeID { get; set; }
        public string aptitudeName { get; set; }
        public string aptitudeDescription { get; set; }

    }
}
