using System.Linq;
using TheNuggetList.Domain.Entities;

namespace TheNuggetList.Domain.Repositories
{
    public class VotesRepository : IVotesRepository
    {
        private readonly TheNuggetsListDbContext _dbContext;

        public VotesRepository(TheNuggetsListDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region IVotesRepository Members

        public IQueryable<Vote> Votes
        {
            get { return _dbContext.Votes.AsQueryable(); }
        }

        public void SaveVote(Vote vote)
        {
            if (vote.ID == 0)
            {
                _dbContext.Votes.Add(vote);
            }

            _dbContext.SaveChanges();
        }

        public IQueryable<Vote> VotesForMember(Member member)
        {
            return _dbContext.Votes.Where(vote => vote.MemberID == member.ID);
        }

        #endregion
    }
}