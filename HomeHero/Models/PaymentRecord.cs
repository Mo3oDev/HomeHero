using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeHero.Models
{
    public class PaymentRecord
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PRecordID { get; set; }
        public int PMethodID { get; set; }
        [ForeignKey("PMethodID")]
        public virtual PayMethod PayMethod { get; set; }
        public byte[] PaymentReceipt {get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
