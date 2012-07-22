using System.Linq;
using TheNuggetList.Domain.Entities;

namespace TheNuggetList.Domain.Repositories
{
    public interface IVotesRepository
    {
        IQueryable<Vote> Votes { get; }
        void SaveVote(Vote vote);
        IQueryable<Vote> VotesForMember(Member member);
    }
}