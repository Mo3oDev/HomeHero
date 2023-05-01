using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeHero.Models
{
    public class Request_Area
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RequestAreaID { get; set; }       
        public int RequestID { get; set; }
        [ForeignKey("RequestID")]
        public virtual Request Request { get; set; }
        public int AreaID { get; set; }
        [ForeignKey("AreaID")]
        public virtual Area Area { get; set; }
    }
}
