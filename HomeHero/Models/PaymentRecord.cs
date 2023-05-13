using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeHero.Models
{
    public class PaymentRecord
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PRecordID { get; set; }
        public int PMethodID_PaymentRecord { get; set; }
        [ForeignKey("PMethodID_PaymentRecord")]
        public virtual PayMethod PayMethod_PaymentRecord { get; set; }
        public byte[] PaymentReceipt {get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
