using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeHero.Models
{
    public class Application
    {
        [Key]
        public int applicantID { get; set; }
        [ForeignKey("")]
        public int userID { get; set; }
        [ForeignKey("")]
        public int requestID { get; set; }
        public decimal requestedPrice { get; set; }
    }
}
