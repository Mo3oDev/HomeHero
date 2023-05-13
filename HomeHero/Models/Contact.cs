using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeHero.Models
{
    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContactID { get; set; }
        public int UserID_Contact { get; set; }
        [ForeignKey("UserID_Contact")]
        public virtual User User_Contact { get; set; }  
        public string NumPhone { get; set; }

    }
}
