#region

using System;

#endregion

namespace TheNuggetList.Domain.Entities
{
    public class MemberStatistics
    {
        public long MemberID { get; set; }
        public long NuggetCount { get; set; }
    }
}