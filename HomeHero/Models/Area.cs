using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeHero.Models
{
    public class Area
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AreaID { get; set; }
        public int NameArea { get; set; }
        public virtual ICollection<Request_Area> Request_Areas { get; set; }
    }
}
