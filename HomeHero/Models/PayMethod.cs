using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeHero.Models
{
    public class PayMethod
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PMethodID { get; set; }
        public string NamePMethod { get; set; }
        public virtual ICollection<PaymentRecord> PaymentRecords { get; set; }  
    }
}
