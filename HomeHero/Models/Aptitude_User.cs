using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HomeHero.Models
{
    public class Aptitude_User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserApID { get; set; }
        public int AptitudeID_Aptitude_User { get; set; }
        [ForeignKey("AptitudeID_Aptitude_User")]
        public virtual Aptitude Aptitude_Aptitude_User { get; set; }
        public int UserID_Aptitude_User { get; set; }
        [ForeignKey("UserID_Aptitude_User")]
        public virtual User User_Aptitude_User { get; set; }  
    }
}
