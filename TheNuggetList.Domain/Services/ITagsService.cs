#region

using System.Collections.Generic;
using System.Linq;
using TheNuggetList.Domain.Entities;

#endregion

namespace TheNuggetList.Domain.Services
{
    public interface ITagsService
    {
        Tag GetTagByID(long id);
        void SaveTag(Tag tag);
        IQueryable<Tag> GetTagsForContentType(IContentType contentObject);
        void AssignTagsByNameToContentType(string csvOfTagNames, IContentType contentObject);
        void AssignTagsByIDToContentType(string csvOfTagIDs, IContentType contentObject);

        IQueryable<Tag> GetTagsByNames(List<string> tagNames);
        List<Nugget> GetNuggetsAssignedToTags(List<Tag> tags);
    }
}