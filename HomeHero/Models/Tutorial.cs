using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeHero.Models
{
    public class Tutorial
    {
        [Key]
        public int tutorialID { get; set; }
        public string tutorialName { get; set; }
        public string tutorialLink { get; set; }
        public DateTime tutorialIPDate { get; set; }
        [ForeignKey("")]
        public int creatorID { get; set; }
    }
}
