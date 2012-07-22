#region

using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using TheNuggetList.Domain.Entities;

#endregion

namespace TheNuggetList.Domain.Repositories
{
    public class TheNuggetsListDbContext : DbContext
    {
        public TheNuggetsListDbContext(DbConnection connection) : base(connection)
        {
        }

        public IDbSet<Nugget> Nuggets { get; set; }
        public IDbSet<Tag> Tags { get; set; }
        public IDbSet<TaggedItem> TaggedItems { get; set; }
        public IDbSet<Member> Members { get; set; }
        public IDbSet<ContentType> ContentTypes { get; set; }
        public IDbSet<MemberStatistics> MemberStatistics { get; set; }
        public IDbSet<Achievement> Achievements { get; set; }
        public IDbSet<EarnedAchievement> EarnedAchievements { get; set; }
        public IDbSet<Comment> Comments { get; set; }
        public IDbSet<Vote> Votes { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Nugget>().MapSingleType().ToTable("Nugget");
            modelBuilder.Entity<Tag>().MapSingleType().ToTable("Tag");
            modelBuilder.Entity<TaggedItem>().MapSingleType().ToTable("TaggedItem");
            modelBuilder.Entity<Member>().MapSingleType().ToTable("Member");
            modelBuilder.Entity<ContentType>().MapSingleType().ToTable("ContentType");
            modelBuilder.Entity<MemberStatistics>().HasKey(ms => ms.MemberID).MapSingleType().ToTable("MemberStatistics");
            modelBuilder.Entity<Achievement>().MapSingleType().ToTable("Achievement");
            modelBuilder.Entity<EarnedAchievement>().MapSingleType().ToTable("EarnedAchievement");
            modelBuilder.Entity<Comment>().MapSingleType().ToTable("Comment");
            modelBuilder.Entity<Vote>().MapSingleType().ToTable("Vote");

            modelBuilder.IncludeMetadataInDatabase = false;
        }
    }
}