using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeHero.Models
{
    public class Request
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RequestID { get; set; }
        public int LocationServiceID { get; set; }
        [ForeignKey("LocationServiceID")]
        public virtual Location Location { get; set; }
        public int ApplicantUserID { get; set; }
        [ForeignKey("ApplicantUserID")]
        public virtual User ApplicantUser { get; set; }
        public string RequestContent { get; set; }
        public DateTime PublicationReqDate { get; set; }
        public int ChatID { get; set; }
        [ForeignKey("ChatID")]
        public virtual Chat Chat { get; set; }
        public int ReqStateID { get; set; }
        [ForeignKey("ReqStateID")]
        public virtual RequestState? RequestState { get; set; }
        public int MembersNeeded { get; set; }
        public byte[] RequestPicture { get; set; }
        public string RequestTitle { get; set; }
        public virtual ICollection<Application>? Applications { get; set; }
        public virtual ICollection<AttentionRequest>? AttentionRequests { get; set; } 
        public virtual ICollection<Complaint>? Complaints { get; set; }
        public virtual ICollection<Qualification>? Qualifications { get; set; }
        public virtual ICollection<Request_Area>? Request_Areas { get; set; }
        
    }
}
