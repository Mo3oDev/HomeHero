using System.ComponentModel.DataAnnotations;

namespace HomeHero.Models
{
    public class Role
    {
        [Key]
        public int roleID { get; set; }
        public string nameRole { get; set; }
    }
}
