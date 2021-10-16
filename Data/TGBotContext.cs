using System.Data.Entity;

namespace BotTelegramDB.Model
{
    public class TGBotContext : DbContext
    {
        public TGBotContext() : base("FbConnection")
        {

        }
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<ListGroup> ListGroups { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
