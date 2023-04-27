using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeHero.Models
{
    public class AttentionRequest
    {
        [Key] 
        public int attentionID { get; set; }
        [ForeignKey("")]
        public int requestID { get; set; }
        [ForeignKey("")]
        public int helperUserID { get; set; }
        public decimal attentionReqValue { get; set; }
        public DateTime attentionDate { get; set; }
        [ForeignKey("")]
        public int paymentRecordID { get; set; }
        public int qualification { get; set; }
    }
}
