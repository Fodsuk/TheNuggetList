#region

using System.Collections.Generic;
using System.Linq;
using TheNuggetList.Domain.Entities;

#endregion

namespace TheNuggetList.Domain.Repositories
{
    public interface ITagsRepository
    {
        IQueryable<Tag> Tags { get; }
        void SaveTag(Tag tag);
        void DeleteTag(Tag tag);
        Tag GetTagByID(long tagID);

        IEnumerable<Tag> GetOrCreateTagByName(IEnumerable<string> newTagNames);
    }
}