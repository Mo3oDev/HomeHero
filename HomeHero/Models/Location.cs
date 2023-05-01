using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeHero.Models
{
    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LocationID { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
    }
}
