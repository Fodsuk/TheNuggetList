namespace TheNuggetList.Domain.Entities
{
    public interface IContentType : IEntity
    {
        string ContentTypeName { get; }
    }
}