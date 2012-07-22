#region

using System.Linq;
using TheNuggetList.Domain.Entities;
using System;

#endregion

namespace TheNuggetList.Domain.Repositories
{
    public class NuggetsRepository : INuggetsRepository
    {
        private readonly TheNuggetsListDbContext _dbContext;
        
        public NuggetsRepository(TheNuggetsListDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region INuggetsRepository Members

        public IQueryable<Nugget> Nuggets
        {
            get { return _dbContext.Nuggets.AsQueryable(); }
        }

        public void SaveNugget(Nugget nugget)
        {
            if (nugget.ID == 0)
            {
                nugget.Created = DateTime.Now;
                _dbContext.Nuggets.Add(nugget);
                
                ICommentsRepository comments = new CommentsRepository(_dbContext);
                comments.SaveCommentEvent += new SaveCommentHandler(comments_AddCommentEvent);
            }

            _dbContext.SaveChanges();
        }

        void comments_AddCommentEvent(object sender, Comment comment)
        {
            throw new NotImplementedException();
        }

        public void DeleteNugget(Nugget nugget)
        {
            _dbContext.Nuggets.Remove(nugget);

            _dbContext.SaveChanges();
        }

        public Nugget GetNuggetByID(long nuggetID)
        {
            return _dbContext.Nuggets.Find(nuggetID);
        }

        #endregion
    }
}