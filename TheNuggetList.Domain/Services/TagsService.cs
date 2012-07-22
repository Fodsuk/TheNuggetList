#region

using System;
using System.Collections.Generic;
using System.Linq;
using TheNuggetList.Domain.Entities;
using TheNuggetList.Domain.Repositories;
using TheNuggetList.Domain.Util;

#endregion

namespace TheNuggetList.Domain.Services
{
    public class TagsService : ITagsService
    {
        private readonly IContentTypesRepository _contentTypesRepo;
        private readonly INuggetsRepository _nuggetsRepo;
        private readonly ITaggedItemsRepository _taggedItemsRepo;
        private readonly ITagsParser _tagsParser;
        private readonly ITagsRepository _tagsRepo;

        public TagsService(IServiceLocator serviceLocator)
        {
            _tagsRepo = serviceLocator.Get<ITagsRepository>();
            _contentTypesRepo = serviceLocator.Get<IContentTypesRepository>();
            _taggedItemsRepo = serviceLocator.Get<ITaggedItemsRepository>();
            _tagsParser = serviceLocator.Get<ITagsParser>();
            _nuggetsRepo = serviceLocator.Get<INuggetsRepository>();
        }

        #region ITagsService Members

        public Tag GetTagByID(long id)
        {
            return _tagsRepo.GetTagByID(id);
        }

        public void SaveTag(Tag tag)
        {
            _tagsRepo.SaveTag(tag);
        }

        public IQueryable<Tag> GetTagsForContentType(IContentType contentObject)
        {
            var contentTypeID = _contentTypesRepo.GetIDForContentType(contentObject);
            var contentObjectPK = contentObject.ID;

            var tags = from t in _tagsRepo.Tags
                       join ti in _taggedItemsRepo.TaggedItems on t.ID equals ti.TagID
                       where (ti.ContentTypeID == contentTypeID) && (ti.ContentObjectPK == contentObjectPK)
                       select t;

            return tags;
        }

        public void AssignTagsByNameToContentType(string tagsString, IContentType contentObject)
        {
            var tagNameList = _tagsParser.GetList(tagsString);

            var existingTagNames = GetTagsForContentType(contentObject).Select(x => x.Name);
            var newTagNames = tagNameList.Except(existingTagNames);

            var tags = _tagsRepo.GetOrCreateTagByName(newTagNames);
            var taggedItems = new List<TaggedItem>();

            foreach (var t in tags)
            {
                taggedItems.Add(new TaggedItem
                                    {
                                        ContentObjectPK = contentObject.ID,
                                        ContentTypeID = _contentTypesRepo.GetIDForContentType(contentObject),
                                        TagID = t.ID
                                    });
            }

            _taggedItemsRepo.SaveTaggedItems(taggedItems);
        }

        public void AssignTagsByIDToContentType(string csvOfTagIDs, IContentType contentObject)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Tag> GetTagsByNames(List<string> tagNames)
        {
            var tags = from t in _tagsRepo.Tags
                       join tn in tagNames on t.Name equals tn
                       select t;

            return tags;
        }

        public List<Nugget> GetNuggetsAssignedToTags(List<Tag> tags)
        {
            var nuggetIds = GetContentTypeIDsAssignedToTags<Nugget>(tags);

            var nuggets = from n in _nuggetsRepo.Nuggets
                          join nid in nuggetIds on n.ID equals nid
                          select n;

            return nuggets.ToList();
        }

        #endregion

        public IQueryable<TaggedItem> GetTaggedItemsForTags(List<Tag> tags)
        {
            var tagids = tags.Select(x => x.ID);
            return from ti in _taggedItemsRepo.TaggedItems
                   where tagids.Contains(ti.TagID)
                   select ti;
        }


        private IEnumerable<long> GetContentTypeIDsAssignedToTags<T>(List<Tag> tags) where T : IContentType
        {
            var contentID = _contentTypesRepo.GetIDForContentType<T>();

            var taggedItems = GetTaggedItemsForTags(tags).Where(x => x.ContentTypeID == contentID);
            var taggedItemPKs = taggedItems.Select(x => x.ContentObjectPK).Distinct();

            var ids = from t in taggedItemPKs
                      let taggedItemsCount = taggedItems.Where(x => x.ContentObjectPK == t).Count()
                      where taggedItemsCount >= tags.Count
                      select t;
            return ids;
        }
    }
}