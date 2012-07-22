#region

#endregion

namespace TheNuggetList.Domain.Entities
{
    public class TaggedItem : IEntity
    {
        public long TagID { get; set; }
        public long ContentTypeID { get; set; }
        public long ContentObjectPK { get; set; }

        #region IEntity Members

        public long ID { get; set; }

        #endregion
    }
}