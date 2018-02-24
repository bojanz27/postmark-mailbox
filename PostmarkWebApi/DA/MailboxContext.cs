using System.Data.Entity;

namespace PostmarkWebApi.DA
{
    public class MailboxContext : DbContext
    {
        public MailboxContext()
            : base("name=MailboxContext")
        {
        }

        public virtual DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
