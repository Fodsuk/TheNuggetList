using System.Collections.Generic;
using System.Linq;
using TheNuggetList.Domain.Entities;

namespace TheNuggetList.Domain.Repositories
{
    public interface IEarnedAchievementsRepository
    {
        IQueryable<EarnedAchievement> EarnedAchievements { get; }
        void SaveEarnedAchievement(EarnedAchievement earnedAchievement);
        void DeleteEarnedAchievement(EarnedAchievement earnedAchievement);
        EarnedAchievement GetEarnedAchievementByID(long earnedAchievementID);
        List<EarnedAchievement> GetEarnedAchievementsForMember(long memberID);
    }
}
