using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EventAggregator;
using TheNuggetList.Domain.Achievements.Listeners;
using TheNuggetList.Domain.Services;

namespace TheNuggetList.Domain.Achievements
{
	public class AchievementListenersRegistration : IAchievementListenersRegistration
	{
		private IServiceLocator _serviceLocator;

		public AchievementListenersRegistration(IServiceLocator serviceLocator)
		{
			_serviceLocator = serviceLocator;
		}

		public void RegisterListeners()
		{
			IEventAggregator eventAggregator = _serviceLocator.Get<IEventAggregator>();

			eventAggregator.AddListener(_serviceLocator.Get<IMemberRegisteredAchievementListener>());
		}
	}
}
