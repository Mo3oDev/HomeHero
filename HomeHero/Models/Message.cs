using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeHero.Models
{
    public class Message
    {
        [Key]
        public int mesaggeID { get; set; }
        [ForeignKey("")]
        public int chatID { get; set; }
        [ForeignKey("")]
        public int userChatID { get; set; }
        public string messageContent { get; set; }
        public DateTime dateMessage { get; set; }
    }
}
