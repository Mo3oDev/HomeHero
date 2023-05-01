using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeHero.Models
{
    public class RequestState
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReqStateID { get; set; }    
        public int NameState { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
    }
}
