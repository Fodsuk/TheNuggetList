using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EventAggregator;
using TheNuggetList.Domain.Entities;

namespace TheNuggetList.Domain.Events
{
	public class MemberRegisteredEvent : IEvent
	{
		public MemberRegisteredEvent(Member registeredMember) 
		{
			this.RegisteredMember = registeredMember;
		}

		public Member RegisteredMember { get; private set; }
	}
}
