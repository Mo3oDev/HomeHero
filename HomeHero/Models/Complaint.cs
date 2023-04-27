using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeHero.Models
{
    public class Complaint
    {
        [Key]
        public int complaintID { get; set; }
        [ForeignKey("")]
        public int unsatisfiedUserID { get; set; }
        [ForeignKey("")]
        public int userAttenderID { get; set; }
        [ForeignKey("")]
        public int ComplaintedUserID { get; set; }
        [ForeignKey("")]
        public int requestComplaintID { get; set; }
        public string ComplaintMessage { get; set; }
        public string ComplaimentState { get; set; }

    }
}
