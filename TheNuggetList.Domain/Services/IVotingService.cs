using TheNuggetList.Domain.Entities;

namespace TheNuggetList.Domain.Services
{
    public interface IVotingService
    {
        void UpVoteContent(long contentObjectPK, string contentTypeName);
        void DownVoteContent(long contentObjectPK, string contentTypeName);
        int NumberOfVotesForContent(long contentObjectPK, string contentTypeName);
    }
}