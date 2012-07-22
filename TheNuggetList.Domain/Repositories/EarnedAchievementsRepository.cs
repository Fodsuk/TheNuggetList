#region

using System.Collections.Generic;
using System.Linq;
using TheNuggetList.Domain.Entities;

#endregion

namespace TheNuggetList.Domain.Repositories
{
    public class EarnedAchievementsRepository : IEarnedAchievementsRepository
    {
        private readonly TheNuggetsListDbContext _dbContext;

        public EarnedAchievementsRepository(TheNuggetsListDbContext context)
        {
            _dbContext = context;
        }

        #region ITaggedItemsRepository Members

        public IQueryable<EarnedAchievement> EarnedAchievements
        {
            get { return _dbContext.EarnedAchievements.AsQueryable(); }
        }

        public void SaveEarnedAchievement(EarnedAchievement earnedAchievement)
        {
            if (earnedAchievement.ID == 0)
            {
                _dbContext.EarnedAchievements.Add(earnedAchievement);
            }

            _dbContext.SaveChanges();
        }

        public void DeleteEarnedAchievement(EarnedAchievement earnedAchievement)
        {
            _dbContext.EarnedAchievements.Remove(earnedAchievement);

            _dbContext.SaveChanges();
        }

        public EarnedAchievement GetEarnedAchievementByID(long earnedAchievementID)
        {
            return _dbContext.EarnedAchievements.Find(earnedAchievementID);
        }

        public List<EarnedAchievement> GetEarnedAchievementsForMember(long memberID)
        {
            return _dbContext.EarnedAchievements.Where(x => x.ContentTypeID == (int)ContentTypes.Member && x.ContentObjectPK == memberID).ToList();
        }

        #endregion
    }
}