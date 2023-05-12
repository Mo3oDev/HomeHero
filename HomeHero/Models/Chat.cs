using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeHero.Models
{
    public class Chat
    {
        public int ChatID { get; set; }
        public int RequestID { get; set; }
        public virtual Request Request { get; set; }
        public DateTime ChatCreationDate { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }

    public class ChatConfiguration : IEntityTypeConfiguration<Chat>
    {
        public void Configure(EntityTypeBuilder<Chat> builder)
        {
            builder.HasKey(c => c.ChatID);

            builder.HasOne(c => c.Request)
                .WithMany()
                .HasForeignKey(c => c.RequestID)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}