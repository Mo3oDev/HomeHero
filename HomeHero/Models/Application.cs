using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeHero.Models
{
    public class Application
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ApplicantID { get; set; }      
        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual User User { get; set; }    
        public int RequestID { get; set; }
        [ForeignKey("RequestID")]
        public virtual Request? Request { get; set; }
        public decimal RequestedPrice { get; set; }
    }
}
