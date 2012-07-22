#region

using System;
using System.Linq;
using TheNuggetList.Domain.Entities;

#endregion

namespace TheNuggetList.Domain.Repositories
{
    public struct ContentKeys
    {
        public long ContentTypeID;
        public long ContentObjectPK;
    }

    public interface IContentTypesRepository
    {
        IQueryable<ContentType> ContentTypes { get; }
        void SaveContentType(ContentType contentType);
        void DeleteContentType(ContentType contentType);
        ContentType GetContentTypeByID(long contentTypeID);

        long GetIDForContentType(IContentType contentType);
        long GetIDForContentType<T>() where T : IContentType;
        long GetIDByName(string contentTypeName);

        ContentKeys GetContentKeysForContentType(IContentType contentType);

    }
}