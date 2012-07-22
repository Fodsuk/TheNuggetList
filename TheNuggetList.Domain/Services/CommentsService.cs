using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheNuggetList.Domain.Entities;
using TheNuggetList.Domain.Repositories;

namespace TheNuggetList.Domain.Services
{
    public class CommentsService : ICommentsService
    {
        private readonly ICommentsRepository _repository;
        private readonly IContentTypesRepository _contentTypeRepo;

        public CommentsService(IServiceLocator serviceLocator)
        {
            _repository = serviceLocator.Get<ICommentsRepository>();
            _contentTypeRepo = serviceLocator.Get<IContentTypesRepository>();
        }

        public Comment GetCommentByID(long id)
        {
            return _repository.GetCommentByID(id);
        }

        public void SaveComment(Comment comment)
        {
            _repository.SaveComment(comment);
        }

        public void SaveComment(long contentObjectPK, string contentTypeName, string content)
        {
            long contentTypeID = _contentTypeRepo.GetIDByName(contentTypeName);

            SaveComment(new Comment() { Content = content,
                                        ContentObjectPK = contentObjectPK, 
                                        ContentTypeID = contentTypeID });

        }

        public IQueryable<Comment> GetCommentsForContentType(IContentType contentType)
        {
            var contentKeys = _contentTypeRepo.GetContentKeysForContentType(contentType);

            return GetCommentsForContentType(contentKeys.ContentObjectPK, contentKeys.ContentTypeID);
        }
        
        public IQueryable<Comment> GetCommentsForContentType(long contentObjectPK, string contentTypeName)
        {
            long contentTypeID = _contentTypeRepo.GetIDByName(contentTypeName);

            return GetCommentsForContentType(contentObjectPK, contentTypeID);
         
        }
        
        public IQueryable<Comment> GetCommentsForContentType(long contentObjectPK, long contentTypeID)
        {
            var comments = _repository.Comments.Where(c => c.ContentObjectPK == contentObjectPK
                                           & c.ContentTypeID == contentTypeID);

            return comments;
        }

    }
}
