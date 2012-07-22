using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheNuggetList.Domain.Entities
{
	public class Achievement : IContentType
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public DateTime Created { get; set; }

        #region IEntity Members

        public long ID { get; set; }

		public string ContentTypeName
		{
			get { return "Achievement"; }
		}

        #endregion
	}

	public enum AchievementID
	{
		MemberRegistered = 3
	}
}
