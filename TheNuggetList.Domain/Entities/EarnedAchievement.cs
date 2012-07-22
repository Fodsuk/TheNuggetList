#region

#endregion

using System;
namespace TheNuggetList.Domain.Entities
{
    public class EarnedAchievement : IEntity
    {
        public long AchievementID { get; set; }
        public long ContentTypeID { get; set; }
        public long ContentObjectPK { get; set; }
        public DateTime Created { get; set; }
		public Achievement Achievement { get; set; }

        #region IEntity Members

        public long ID { get; set; }

        #endregion
    }
}