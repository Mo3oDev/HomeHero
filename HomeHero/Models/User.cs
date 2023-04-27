using System.ComponentModel.DataAnnotations.Schema;

namespace HomeHero.Models
{
    public class User
    {
        public int userId { get; set; }
        [ForeignKey("")]
        public int roleID { get; set; }
        public string realUserID { get; set; }
        public string namesUser { get; set; }
        public string surnamesUser { get; set; }
        public int qualificationUser { get; set; }
        public string password { get; set; }
        [ForeignKey("")]
        public int locationResidenceID { get; set; }
        public char sexUser { get; set; }
        public byte[] curriculum { get; set; }
        public bool volunteerPermises { get; set; }
    }
}
