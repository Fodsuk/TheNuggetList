using System.Linq;
using TheNuggetList.Domain.Entities;

namespace TheNuggetList.Domain.Repositories
{
    public interface IAchievementsRepository
    {
        IQueryable<Achievement> Achievements { get; }
        Achievement GetAchievementByID(long achievementID);
    }
}
