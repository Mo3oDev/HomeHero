using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeHero.Models
{
    public class Request
    {
        [Key]
        public int requestID { get; set; }
        [ForeignKey("")]
        public int locationServiceID { get; set; }
        [ForeignKey("")]
        public int applicantUserID { get; set; }
        public string requestContent { get; set; }
        public DateTime publicationReqDate { get; set; }
        [ForeignKey("")]
        public int chatID { get; set; }
        [ForeignKey("")]
        public int requestState { get; set; }
        public int membersNeeded { get; set; }
        public byte[] requestPicture { get; set; }
        public string requestTitle { get; set; }
    }
}
