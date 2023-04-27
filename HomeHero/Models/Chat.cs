using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeHero.Models
{
    public class Chat
    {
        [Key]
        public int chatID { get; set; }
        [ForeignKey("")]
        public int requestID { get; set; }
        public DateTime chatCreationDate { get; set; } 
    }
}
