using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheNuggetList.Domain.Events;
using TheNuggetList.Domain.Services;
using EventAggregator;
using TheNuggetList.Domain.Entities;

namespace TheNuggetList.Domain.Achievements.Listeners
{
	public class MemberRegisteredAchievementListener : AchievementListener, IMemberRegisteredAchievementListener
	{

		public MemberRegisteredAchievementListener(IServiceLocator serviceLocator)
			:base(serviceLocator)
		{

		}

		public void Handle(MemberRegisteredEvent message)
		{
			Member registeredMember = message.RegisteredMember;

			assignAchievementToMember(registeredMember, AchievementID.MemberRegistered);
		}
	}
}
