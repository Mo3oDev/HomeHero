using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeHero.Models
{
    public class AttentionRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AttentionID { get; set; }      
        public int RequestID { get; set; }
        [ForeignKey("RequestID")]
        public virtual Request? Request { get; set; }
        public int HelperUserID { get; set; }
        [ForeignKey("HelperUserID")]
        public virtual User? User { get; set; }
        public decimal AttentionReqValue { get; set; }
        public DateTime AttentionDate { get; set; }    
        public int PaymentRecordID { get; set; }
        [ForeignKey("PaymentRecordID")]
        public virtual PaymentRecord PaymentRecord { get; set; }
        public int Qualification { get; set; }
    }
}
