#region

using System.Collections.Generic;
using System.Linq;
using TheNuggetList.Domain.Entities;

#endregion

namespace TheNuggetList.Domain.Repositories
{
    public class TaggedItemsRepository : ITaggedItemsRepository
    {
        private readonly TheNuggetsListDbContext _dbContext;

        public TaggedItemsRepository(TheNuggetsListDbContext context)
        {
            _dbContext = context;
        }

        #region ITaggedItemsRepository Members

        public IQueryable<TaggedItem> TaggedItems
        {
            get { return _dbContext.TaggedItems.AsQueryable(); }
        }

        public void SaveTaggedItem(TaggedItem TaggedItem)
        {
            if (TaggedItem.ID == 0)
            {
                _dbContext.TaggedItems.Add(TaggedItem);
            }

            _dbContext.SaveChanges();
        }

        public void DeleteTaggedItem(TaggedItem taggedItem)
        {
            _dbContext.TaggedItems.Remove(taggedItem);

            _dbContext.SaveChanges();
        }

        public TaggedItem GetTaggedItemByID(long taggedItemID)
        {
            return _dbContext.TaggedItems.Find(taggedItemID);
        }

        public void SaveTaggedItems(List<TaggedItem> taggedItems)
        {
            foreach (var taggedItem in taggedItems)
            {
                _dbContext.TaggedItems.Add(taggedItem);
            }

            _dbContext.SaveChanges();
        }

        #endregion
    }
}