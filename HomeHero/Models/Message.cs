using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeHero.Models
{
    public class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MesaggeID { get; set; }      
        public int ChatID { get; set; }
        [ForeignKey("ChatID")]
        public virtual Chat? Chat { get; set; }
        public int UserChatID { get; set; }
        [ForeignKey("UserChatID")]
        public virtual User User { get; set; }
        public string MessageContent { get; set; }
        public DateTime DateMessage { get; set; }
    }
}
