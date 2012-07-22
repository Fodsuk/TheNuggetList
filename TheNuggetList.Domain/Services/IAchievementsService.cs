#region

using TheNuggetList.Domain.Entities;
using TheNuggetList.Domain.Util.Paging;

#endregion

namespace TheNuggetList.Domain.Services
{
	public interface IAchievementsService
    {
		PagedList<Achievement> GetPagedAchievements(int currentPage, int pageSize, int pageLinksToDisplay);
		Achievement GetAchievementByID(long id);

		PagedList<EarnedAchievement> GetPagedEarnedAchievementsForMember(Member member, int currentPage, int pageSize, int pageLinksToDisplay);
    }
}