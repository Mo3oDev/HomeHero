using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeHero.Models
{
    public class Qualification
    {
        [Key]
        public int qualificationID { get; set; }
        public decimal qualification { get; set; }
        [ForeignKey("")]
        public int helperUserID { get; set; }
        [ForeignKey("")]
        public int ApplicantUserID { get; set; }
        [ForeignKey("")]
        public int requestID { get; set; }
        public string comment { get; set; }


    }
}
