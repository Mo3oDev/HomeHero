using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeHero.Models
{
    public class Contact
    {
        [Key]     
        public int contactID { get; set; }
        [ForeignKey("")]
        public int userID { get; set; }
        public string numPhone { get; set; }
        public string emailUser { get; set; }

    }
}
