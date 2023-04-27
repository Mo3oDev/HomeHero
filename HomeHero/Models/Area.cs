using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeHero.Models
{
    public class Area
    {
        [Key]
        public int areaID { get; set; }
        public int nameArea { get; set; }

    }
}
