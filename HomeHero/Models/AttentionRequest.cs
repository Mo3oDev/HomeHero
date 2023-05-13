using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeHero.Models
{
    public class AttentionRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AttentionID { get; set; }      
        public int RequestID_AttentionRequest { get; set; }
        [ForeignKey("RequestID_AttentionRequest")]
        public virtual Request Request_AttentionRequest { get; set; }
        public int HelperUserID { get; set; }
        [ForeignKey("HelperUserID")]
        public virtual User? HelperUser { get; set; }
        public decimal AttentionReqValue { get; set; }
        public DateTime AttentionDate { get; set; }
        //public int PaymentRecordID_AttentionRequest { get; set; }
        //[ForeignKey("PaymentRecordID_AttentionRequest")]
        //public virtual PaymentRecord PaymentRecord_AttentionRequest { get; set; }
        public virtual ICollection<PaymentRecord> PaymentRecords { get; set; }
        public int Qualification { get; set; }
    }
}
