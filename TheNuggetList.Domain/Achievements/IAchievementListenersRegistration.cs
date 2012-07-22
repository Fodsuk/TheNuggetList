using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EventAggregator;

namespace TheNuggetList.Domain.Achievements
{
	public interface IAchievementListenersRegistration
	{
		void RegisterListeners();
	}
}
