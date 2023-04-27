using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeHero.Models
{
    public class PaymentRecord
    {
        [Key]
        public int pRecordID { get; set; }
        [ForeignKey("")]
        public int pMethodID { get; set; }
        public byte[] paymentReceipt {get; set; }
        public DateTime paymentDate { get; set; }


    }
}
