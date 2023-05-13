using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeHero.Models
{
    public class Chat
    {
        public int ChatID { get; set; }
        [ForeignKey("RequestID_Chat")]
        public int RequestID_Chat { get; set; }
        public virtual Request Request_Chat { get; set; }
        public DateTime ChatCreationDate { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }

    
}