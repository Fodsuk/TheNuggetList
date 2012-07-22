#region

using System;
using System.Linq;
using TheNuggetList.Domain.Entities;

#endregion

namespace TheNuggetList.Domain.Repositories
{
    public class ContentTypesRepository : IContentTypesRepository
    {
        private readonly TheNuggetsListDbContext _dbContext;

        public ContentTypesRepository(TheNuggetsListDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region IContentTypesRepository Members

        public IQueryable<ContentType> ContentTypes
        {
            get { return _dbContext.ContentTypes; }
        }

        public void SaveContentType(ContentType contentType)
        {
            if (contentType.ID == 0)
            {
                _dbContext.ContentTypes.Add(contentType);
            }

            _dbContext.SaveChanges();
        }

        public void DeleteContentType(ContentType contentType)
        {
            _dbContext.ContentTypes.Remove(contentType);

            _dbContext.SaveChanges();
        }

        public ContentType GetContentTypeByID(long contentTypeID)
        {
            return _dbContext.ContentTypes.Find(contentTypeID);
        }

        public long GetIDForContentType(IContentType contentType)
        {
            var matchedContentType = _dbContext.ContentTypes.Where(ct => ct.Name == contentType.ContentTypeName).First();
            return matchedContentType.ID;
        }

        public long GetIDForContentType<T>() where T : IContentType
        {
            var instance = Activator.CreateInstance<T>();
            return GetIDForContentType(instance);
        }

        public ContentKeys GetContentKeysForContentType(IContentType contentType)
        {
            return new ContentKeys()
                       {
                           ContentTypeID = GetIDForContentType(contentType),
                           ContentObjectPK = contentType.ID
                       };
        }

        #endregion


        public long GetIDByName(string contentTypeName)
        {
            return _dbContext.ContentTypes.Where(ct => ct.Name == contentTypeName).First().ID;            
        }
    }
}