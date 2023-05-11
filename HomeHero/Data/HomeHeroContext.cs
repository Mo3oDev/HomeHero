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
        public DbSet<Application> Application { get; set; }
        public DbSet<Aptitude> Aptitude { get; set; }
        public DbSet<Aptitude_User> Aptitude_User { get; set; }
        public DbSet<Area> Area { get; set; }
        public DbSet<AttentionRequest> AttentionRequest { get; set; }
        public DbSet<Chat> Chat { get; set; }
        public DbSet<Complaint> Complaint { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Doubt> Doubt { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<PaymentRecord> PaymentRecord { get; set; }
        public DbSet<PayMethod> PayMethod { get; set; }
        public DbSet<Qualification> Qualification { get; set; }
        public DbSet<HomeHero.Models.Request> Request { get; set; }
        public DbSet<Request_Area> Request_Area { get; set; }
        public DbSet<RequestState> RequestState { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Tutorial> Tutorial { get; set; }
        public DbSet<User> User { get; set; }
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
            //modelBuilder.Entity<HomeHero.Models.Request>()
            //   .HasOne(r => r.ApplicantUser)
            //   .WithMany()
            //   .HasForeignKey(r => r.ApplicantUserID)
            //   .OnDelete(DeleteBehavior.NoAction);
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
