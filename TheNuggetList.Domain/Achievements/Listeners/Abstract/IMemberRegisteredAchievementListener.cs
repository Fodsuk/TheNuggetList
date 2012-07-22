using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EventAggregator;
using TheNuggetList.Domain.Events;

namespace TheNuggetList.Domain.Achievements.Listeners
{
	public interface IMemberRegisteredAchievementListener : IListenTo<MemberRegisteredEvent>.All
	{
	}
}
