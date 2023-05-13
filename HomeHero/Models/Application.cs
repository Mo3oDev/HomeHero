using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeHero.Models
{
    public class Application
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ApplicationID { get; set; }
        [ForeignKey("UserID_Application")]
        public int UserID_Application { get; set; }
        public  User User_Application { get; set; }
        [ForeignKey("RequestID_Application")]
        public int RequestID_Application { get; set; }
        public  Request Request_Application { get; set; }
        public decimal RequestedPrice { get; set; }
    }
}
