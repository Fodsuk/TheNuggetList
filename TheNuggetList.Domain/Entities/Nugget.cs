#region

using System;

#endregion

namespace TheNuggetList.Domain.Entities
{
    public class Nugget : IContentType
    {
        public long MemberID { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public Member Member { get; set; }
        public DateTime Created { get; set; }

        #region IContentType Members

        public long ID { get; set; }

        public string ContentTypeName
        {
            get { return "Nugget"; }
        }

        #endregion
    }
}