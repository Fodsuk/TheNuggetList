using System.Collections.Generic;
using System.Linq;
using TheNuggetList.Domain.Entities;

namespace TheNuggetList.Domain.Repositories
{
    public interface ITaggedItemsRepository
    {
        IQueryable<TaggedItem> TaggedItems { get; }
        void SaveTaggedItem(TaggedItem taggedItem);
        void DeleteTaggedItem(TaggedItem taggedItem);
        TaggedItem GetTaggedItemByID(long taggedItemID);

        void SaveTaggedItems(List<TaggedItem> taggedItems);
    }
}
