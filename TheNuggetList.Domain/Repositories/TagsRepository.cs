#region

using System.Collections.Generic;
using System.Linq;
using TheNuggetList.Domain.Entities;

#endregion

namespace TheNuggetList.Domain.Repositories
{
    public class TagsRepository : ITagsRepository
    {
        private readonly TheNuggetsListDbContext _dbContext;

        public TagsRepository(TheNuggetsListDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region ITagsRepository Members

        public IQueryable<Tag> Tags
        {
            get { return _dbContext.Tags; }
        }

        public void SaveTag(Tag tag)
        {
            if (tag.ID == 0)
            {
                _dbContext.Tags.Add(tag);
            }

            _dbContext.SaveChanges();
        }

        public void DeleteTag(Tag tag)
        {
            _dbContext.Tags.Remove(tag);

            _dbContext.SaveChanges();
        }

        public Tag GetTagByID(long tagID)
        {
            return _dbContext.Tags.Find(tagID);
        }

        public IEnumerable<Tag> GetOrCreateTagByName(IEnumerable<string> tagNames)
        {
            var tags = new List<Tag>();

            foreach (var tagName in tagNames)
            {
                var tag = GetTagByName(tagName);

                if (tag == null)
                {
                    tag = new Tag {Name = tagName};
                    _dbContext.Tags.Add(tag);
                }

                tags.Add(tag);
            }

            _dbContext.SaveChanges();
            return tags;
        }

        #endregion

        public Tag GetTagByName(string tagName)
        {
            return _dbContext.Tags.Where(t => t.Name == tagName).FirstOrDefault();
        }
    }
}