namespace TheNuggetList.Domain.Entities
{
    public class Tag : IEntity
    {
        public string Name { get; set; }

        #region IEntity Members

        public long ID { get; set; }

        #endregion
    }
}