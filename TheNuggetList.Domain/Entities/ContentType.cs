#region



#endregion

namespace TheNuggetList.Domain.Entities
{
    public class ContentType : IEntity
    {
        public string Name { get; set; }

        #region IEntity Members

        public long ID { get; set; }

        #endregion
    }

    public enum ContentTypes
    {
        Nugget = 1,
        Member = 2,
    }
}