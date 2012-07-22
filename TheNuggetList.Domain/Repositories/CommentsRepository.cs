#region

using System.Linq;
using TheNuggetList.Domain.Entities;
using System;

#endregion

namespace TheNuggetList.Domain.Repositories
{
    public class CommentsRepository : ICommentsRepository
    {
        private readonly TheNuggetsListDbContext _dbContext;
        public event SaveCommentHandler SaveCommentEvent;

        public CommentsRepository(TheNuggetsListDbContext dbContext)
        {
            _dbContext = dbContext;
            SaveCommentEvent += new SaveCommentHandler(SaveCommentEventFired);
        }     

        public IQueryable<Comment> Comments
        {
            get { return _dbContext.Comments.AsQueryable(); }
        }

        public void SaveComment(Comment comment)
        {
            if (comment.ID == 0)
            {
                comment.Created = DateTime.Now;
                _dbContext.Comments.Add(comment);

                if (SaveCommentEvent != null)
                    SaveCommentEvent(this, comment);
            }

            _dbContext.SaveChanges();
        }

        public void DeleteComment(Comment comment)
        {
            _dbContext.Comments.Remove(comment);

            _dbContext.SaveChanges();
        }

        public Comment GetCommentByID(long commentID)
        {
            return _dbContext.Comments.Find(commentID);
        }

        //event

        void SaveCommentEventFired(object sender, Comment comment)
        {
           // _dbContext.Comments.                   
        }
        
    }
}