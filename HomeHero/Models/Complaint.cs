using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeHero.Models
{
    public class Complaint
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ComplaintID { get; set; }
        public int UnsatisfiedUserID { get; set; }
        [ForeignKey("UnsatisfiedUserID")]
        public virtual User UnsatisfiedUser { get; set; }
        public int AttenderUserID { get; set; }
        [ForeignKey("AttenderUserID")]
        public virtual User AttenderUser { get; set; }
        public int ComplaintedUserID { get; set; }
        [ForeignKey("ComplaintedUserID")]
        public virtual User ComplaintedUser { get; set; }
        [ForeignKey("RequestComplaintID")]
        public int RequestComplaintID { get; set; }
        public virtual Request RequestComplaint { get; set; }

        public string ComplaintMessage { get; set; }
        public string ComplaimentState { get; set; }
    }
}
