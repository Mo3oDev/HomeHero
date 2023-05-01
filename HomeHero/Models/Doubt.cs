using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeHero.Models
{
    public class Doubt
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DoubtID { get; set; }  
        public int QuestionerID { get; set; }
        public virtual User? Questioner { get; set; }
        public int ResponderID { get; set; }
        [ForeignKey("ResponderID")]
        public virtual User? Responder { get; set; }
        public string QuestionContent { get; set; }
        public string AnswerContent { get; set; }
        public DateTime QuestionDate { get; set; }
        public DateTime AnswerDate { get; set;}
    }
}
