using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeHero.Models
{
    public class Tutorial
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TutorialID { get; set; }
        public string TutorialName { get; set; }
        public string TutorialLink { get; set; }
        public DateTime TutorialIPDate { get; set; }     
        public int CreatorID { get; set; }
        [ForeignKey("CreatorID")]
        public virtual User Creator { get; set; }
    }
}
