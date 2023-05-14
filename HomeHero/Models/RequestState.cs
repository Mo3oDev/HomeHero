using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeHero.Models
{
    public class State
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StateID { get; set; }    
        public string NameState { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
        public virtual ICollection<AttentionRequest> AttentionRequests { get; set; }
    }
}
