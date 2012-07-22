using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EventAggregator;
using TheNuggetList.Domain.Events;
using TheNuggetList.Domain.Entities;
using TheNuggetList.Domain.Services;
using TheNuggetList.Domain.Repositories;

namespace TheNuggetList.Domain.Achievements.Listeners
{
	public abstract class AchievementListener
	{
		private readonly IContentTypesRepository _contentTypesRepo;
		private readonly IEarnedAchievementsRepository _earnedAchievementsRepo;
		private readonly IAchievementsRepository _achievementsRepo;

		public AchievementListener(IServiceLocator serviceLocator)
		{
			_contentTypesRepo = serviceLocator.Get<IContentTypesRepository>();
			_earnedAchievementsRepo = serviceLocator.Get<IEarnedAchievementsRepository>();
			_achievementsRepo = serviceLocator.Get<IAchievementsRepository>();

			this.serviceLocator = serviceLocator;
		}

		protected IServiceLocator serviceLocator { get; private set; }

		protected void assignAchievementToMember(Member member, AchievementID achievementID)
		{
			Achievement achievement = _achievementsRepo.Achievements.FirstOrDefault(x => x.ID == (long)achievementID);

			if (achievement != null)
			{
				assignAchievementToMember(member, achievement);
			}
		}

		protected void assignAchievementToMember(Member member, Achievement achievement)
		{
			long contentTypeID = _contentTypesRepo.GetIDForContentType(member);

			Boolean achievementAlreadyEarned = _earnedAchievementsRepo.EarnedAchievements.Any(x => x.AchievementID == achievement.ID && x.ContentObjectPK == member.ID && x.ContentTypeID == contentTypeID);

			if (!achievementAlreadyEarned)
			{
				EarnedAchievement earnedAchievement = new EarnedAchievement()
				{
					ContentObjectPK = member.ID,
					ContentTypeID = contentTypeID,
					AchievementID = achievement.ID,
					Created = DateTime.Now
				};

				_earnedAchievementsRepo.SaveEarnedAchievement(earnedAchievement);
			}
		}
	}
}
