#region

using TheNuggetList.Domain.Entities;
using TheNuggetList.Domain.Util.Paging;
using System.Linq;
using System;

#endregion

namespace TheNuggetList.Domain.Services
{
    public interface ICommentsService
    {
        Comment GetCommentByID(long id);
        void SaveComment(Comment comment);
        void SaveComment(long contentObjectPK, string contentTypeName, string content);

        IQueryable<Comment> GetCommentsForContentType(IContentType contentType);
        IQueryable<Comment> GetCommentsForContentType(long contentObjectPK, long contentTypeID);  
        IQueryable<Comment> GetCommentsForContentType(long contentObjectPK, String contentTypeName);

    }
}