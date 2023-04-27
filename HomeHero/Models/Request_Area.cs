using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeHero.Models
{
    public class Request_Area
    {
        [Key]
        public int reqAreaID { get; set; }
        [ForeignKey("")]
        public int requestID { get; set; }
        [ForeignKey("")]
        public int areaID { get; set; }
    }
}
