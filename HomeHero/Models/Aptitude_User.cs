using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HomeHero.Models
{
    public class Aptitude_User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserApID { get; set; }
        public int AptitudeID { get; set; }
        [ForeignKey("AptitudeID")]
        public virtual Aptitude Aptitude { get; set; }
        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual User User { get; set; }  
    }
}
