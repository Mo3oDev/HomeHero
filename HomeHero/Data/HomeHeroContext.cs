using Azure.Core;
using HomeHero.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace HomeHero.Data
{
    public class HomeHeroContext : DbContext
    {
        public HomeHeroContext(DbContextOptions<HomeHeroContext> options)
            : base(options)
        { }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Aptitude> Aptitudes { get; set; }
        public DbSet<Aptitude_User> Aptitude_Users { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<AttentionRequest> AttentionRequests { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Doubt> Doubts { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<PaymentRecord> PaymentRecords { get; set; }
        public DbSet<PayMethod> PayMethods { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }
        public DbSet<HomeHero.Models.Request> Requests { get; set; }
        public DbSet<Request_Area> Request_Areas { get; set; }
        public DbSet<RequestState> RequestStates { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Tutorial> Tutorials { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Set default values in User Model
            modelBuilder.Entity<User>()
                .Property(p => p.QualificationUser)
                .HasDefaultValue(0);
            modelBuilder.Entity<User>()
                .Property(p => p.VolunteerPermises)
                .HasDefaultValue(false);
            modelBuilder.Entity<User>()
               .Property(p => p.RoleID)
               .HasDefaultValue(2);

            modelBuilder.Entity<Complaint>()
                .HasOne(q => q.AttenderUser)
                .WithMany()
                .HasForeignKey(q => q.AttenderUserID)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Complaint>()
                .HasOne(q => q.UnsatisfiedUser)
                .WithMany()
                .HasForeignKey(q => q.UnsatisfiedUserID)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Complaint>()
                .HasOne(q => q.ComplaintedUser)
                .WithMany()
                .HasForeignKey(q => q.ComplaintedUserID)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Doubt>()
                 .HasOne(d => d.Questioner)
                 .WithMany(u => u.Doubts)
                 .HasForeignKey(d => d.QuestionerID)
                 .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Doubt>()
                .HasOne(d => d.Responder)
                .WithMany()
                .HasForeignKey(d => d.ResponderID)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Qualification>()
               .HasOne(q => q.ApplicantUser)
               .WithMany()
               .HasForeignKey(q => q.ApplicantUserID);
            modelBuilder.Entity<HomeHero.Models.Request>()
               .HasOne(r => r.ApplicantUser)
               .WithMany()
               .HasForeignKey(r => r.ApplicantUserID)
               .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Qualification>()
               .HasOne(r => r.ApplicantUser)
               .WithMany()
               .HasForeignKey(r => r.ApplicantUserID)
               .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Qualification>()
               .HasOne(r => r.HelperUser)
               .WithMany()
               .HasForeignKey(r => r.HelperUserID)
               .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Application>()
               .HasOne(cu => cu.Request)
               .WithMany()
               .HasForeignKey(cu => cu.RequestID)
               .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<AttentionRequest>()
              .HasOne(cu => cu.Request)
              .WithMany()
              .HasForeignKey(cu => cu.RequestID)
              .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Chat>()
             .HasOne(cu => cu.Request)
             .WithMany()
             .HasForeignKey(cu => cu.RequestID)
             .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
