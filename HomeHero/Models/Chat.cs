using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeHero.Models
{
    public class Chat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ChatID { get; set; }
        public int RequestID { get; set; }
        [ForeignKey("RequestID")]
        public Request? Request { get; set; }
        public DateTime ChatCreationDate { get; set; }
        public virtual ICollection<Message> Messages { get; set;}
    }
}
