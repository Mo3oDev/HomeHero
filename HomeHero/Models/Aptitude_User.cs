using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HomeHero.Models
{
    public class Aptitude_User
    {
       
		[Key]
        public int userApID { get; set; }

        [ForeignKey("")]
        public int aptitudeID { get; set; }
        [ForeignKey("")]
        public int userID { get; set; }

    }
}
