using System.ComponentModel.DataAnnotations;

namespace HomeHero.Models
{
    public class PayMethod
    {
        [Key]
        public int pMethodID { get; set; }
        public string namePMethod { get; set; }

    }
}
