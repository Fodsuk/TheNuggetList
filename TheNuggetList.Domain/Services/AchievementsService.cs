#region

using System.Linq;
using TheNuggetList.Domain.Entities;
using TheNuggetList.Domain.Repositories;
using TheNuggetList.Domain.Util.Paging;

#endregion

namespace TheNuggetList.Domain.Services
{
    public class AchievementsService : IAchievementsService
    {
		private readonly IAchievementsRepository _achievementsRepository;
		private readonly IEarnedAchievementsRepository _earnedAchievementsRepository;
		private readonly IContentTypesRepository _contentTypeRepository;

		public AchievementsService(IServiceLocator serviceLocator)
        {
			_achievementsRepository = serviceLocator.Get<IAchievementsRepository>();
			_earnedAchievementsRepository = serviceLocator.Get<IEarnedAchievementsRepository>();
			_contentTypeRepository = serviceLocator.Get<IContentTypesRepository>();
        }

		#region IAchievementsService Members

		public PagedList<Achievement> GetPagedAchievements(int currentPage, int pageSize, int pageLinksToDisplay)
        {
			return _achievementsRepository.Achievements.OrderBy(x => x.ID).ToPagedList(currentPage, pageSize, pageLinksToDisplay);
        }

		public Achievement GetAchievementByID(long id)
        {
			return _achievementsRepository.GetAchievementByID(id);
        }

		public PagedList<EarnedAchievement> GetPagedEarnedAchievementsForMember(Member member, int currentPage, int pageSize, int pageLinksToDisplay)
		{
			var contentKeys = _contentTypeRepository.GetContentKeysForContentType(member);

			return _earnedAchievementsRepository.EarnedAchievements
				.Where(x => x.ContentTypeID == contentKeys.ContentTypeID && x.ContentObjectPK == contentKeys.ContentObjectPK)
				.OrderByDescending(x => x.Created)
				.ToPagedList(currentPage, pageSize, pageLinksToDisplay);
		}

        #endregion
    }
}