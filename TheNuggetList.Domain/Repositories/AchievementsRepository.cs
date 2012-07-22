#region

using System.Linq;
using TheNuggetList.Domain.Entities;

#endregion

namespace TheNuggetList.Domain.Repositories
{
    public class AchievementsRepository : IAchievementsRepository
    {
        private readonly TheNuggetsListDbContext _dbContext;

        public AchievementsRepository(TheNuggetsListDbContext context)
        {
            _dbContext = context;
        }

        #region IAchievementsRepository Members

        public IQueryable<Achievement> Achievements
        {
            get { return _dbContext.Achievements.AsQueryable(); }
        }

        public Achievement GetAchievementByID(long achievementID)
        {
            return _dbContext.Achievements.Find(achievementID);
        }

        #endregion
    }
}