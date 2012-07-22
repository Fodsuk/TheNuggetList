using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheNuggetList.Domain.Entities;

namespace TheNuggetList.Domain.Repositories
{
    public delegate void SaveCommentHandler(object sender, Comment comment);

    public interface ICommentsRepository
    {
        IQueryable<Comment> Comments { get; }
        void SaveComment(Comment comment);
        void DeleteComment(Comment comment);
        Comment GetCommentByID(long commentID);

        event SaveCommentHandler SaveCommentEvent;
    }
    
}
