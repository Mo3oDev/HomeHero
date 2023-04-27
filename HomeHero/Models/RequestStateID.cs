using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeHero.Models
{
    public class RequestStateID
    {
        [Key]
        public int ReqStateID { get; set; }
       
        public int nameState { get; set; }
    }
}
