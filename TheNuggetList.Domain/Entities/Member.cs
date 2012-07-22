#region

using System;

#endregion

namespace TheNuggetList.Domain.Entities
{
	public class Member : IContentType
    {
        public String EmailAddress { get; set; }
        public String Password { get; set; }
        public String DisplayName { get; set; }

        #region IEntity Members

        public long ID { get; set; }

		public string ContentTypeName
		{
			get { return "Member"; }
		}

        #endregion
    }
}