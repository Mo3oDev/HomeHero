using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeHero.Models
{
    public class Aptitude
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AptitudeID { get; set; }
        public string AptitudeName { get; set; }
        public string AptitudeDescription { get; set; }
        public virtual ICollection<Aptitude_User> Aptitude_Users { get; set; }
    }
}
