using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeHero.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public int RoleID_User { get; set; }
        [ForeignKey("RoleID_User")] 
        public virtual Role Role_User { get; set; }
        public string? RealUserID { get; set; }
        public string NamesUser { get; set; }
        public string SurnamesUser { get; set; }
        public byte[] ProfilePicture { get; set; }
        public byte[] VolunteerVoucher { get; set; }
        public int QualificationUser { get; set; }
        public string Email  { get; set; }

        [Column(TypeName = "varbinary(max)")]
        public byte[] Password { get; set; }
        public byte[] Salt { get; set; }
        public int LocationResidenceID { get; set; }
        [ForeignKey("LocationResidenceID")]
        public virtual Location LocationResidence { get; set; }
        public char? SexUser { get; set; }
        public byte[]? Curriculum { get; set; }
        public bool? VolunteerPermises { get; set; }
        public virtual ICollection<Application>? Applications { get; set; }
        public virtual ICollection<Aptitude_User>? Aptitude_Users { get; }
        public virtual ICollection<AttentionRequest>? AttentionRequests { get; set; }
        public virtual ICollection<Message>? Messages { get; set; }
        //Relations with Complaint Entity
       
        public virtual ICollection<Complaint>? UnsatisfiedUsers { get; set; }
        public virtual ICollection<Complaint>? AttenderUsers { get; set; }
        public virtual ICollection<Complaint>? ComplaintedUsers { get; set; }
        

        public virtual ICollection<Contact>? Contacts { get; set; }
        public virtual ICollection<Doubt>? Doubts { get; set; }
        public virtual ICollection<Qualification>? Qualifications { get; set; }
        public virtual ICollection<Request>? Requests { get; set; }
        public virtual ICollection<Tutorial>? Tutorials { get; set; }

    }
}
