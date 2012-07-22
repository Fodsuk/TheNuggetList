namespace TheNuggetList.Domain.Entities
{
    public class Vote : IEntity
    {
        public long ContentTypeID { get; set; }
        public long ContentObjectPK { get; set; }
        public long MemberID { get; set; }
        public int VoteValue { get; set; }

        #region IEntity Members

        public long ID { get; set; }

        #endregion
    }
}