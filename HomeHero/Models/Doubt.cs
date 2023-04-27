using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeHero.Models
{
    public class Doubt
    {
        [Key]
        public int DoubtID { get; set; }
        [ForeignKey("")]
        public string questionerID { get; set; }
        [ForeignKey("")]
        public string responderID { get; set; }
        public string questionContent { get; set; }
        public string answerContent { get; set; }
        public DateTime questionDate { get; set; }
        public DateTime answerDate { get; set;}
    }
}
