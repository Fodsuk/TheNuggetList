using System.Linq;
using TheNuggetList.Domain.Entities;
using TheNuggetList.Domain.Repositories;

namespace TheNuggetList.Domain.Services
{
    public class VotingService : IVotingService
    {
        private readonly IContentTypesRepository _contentTypeRepository;
        private readonly IMemberAuthenticationService _membersAuthService;
        private readonly IVotesRepository _votesRepository;

        public VotingService(IServiceLocator serviceLocator)
        {
            _votesRepository = serviceLocator.Get<IVotesRepository>();
            _contentTypeRepository = serviceLocator.Get<IContentTypesRepository>();
            _membersAuthService = serviceLocator.Get<IMemberAuthenticationService>();
        }

        #region IVotingService Members

        public void UpVoteContent(long contentObjectPK, string contentTypeName)
        {
            if (_membersAuthService.LoggedIn)
            {
                var contentTypeID = _contentTypeRepository.GetIDByName(contentTypeName);

                if (!MemberHasVotedForContent(contentObjectPK, contentTypeID, _membersAuthService.LoggedInMember.ID))
                {
                    UpVoteContent(contentObjectPK, contentTypeID);
                }
            }
        }

        public void DownVoteContent(long contentObjectPK, string contentTypeName)
        {
            if (_membersAuthService.LoggedIn)
            {
                var contentTypeID = _contentTypeRepository.GetIDByName(contentTypeName);

                if (!MemberHasVotedForContent(contentObjectPK, contentTypeID, _membersAuthService.LoggedInMember.ID))
                {
                    DownVoteContent(contentObjectPK, contentTypeID);
                }
            }
        }

        public int NumberOfVotesForContent(long contentObjectPK, string contentTypeName)
        {
            var contentTypeID = _contentTypeRepository.GetIDByName(contentTypeName);
            return NumberOfVotesForContent(contentObjectPK, contentTypeID);
        }

        #endregion

        private void UpVoteContent(long contentObjectPK, long contentTypeID)
        {
            var vote = BuildVoteForContentType(contentObjectPK, contentTypeID, _membersAuthService.LoggedInMember.ID, 1);
            _votesRepository.SaveVote(vote);
        }

        private void DownVoteContent(long contentObjectPK, long contentTypeID)
        {
            var vote = BuildVoteForContentType(contentObjectPK, contentTypeID, _membersAuthService.LoggedInMember.ID, -1);
            _votesRepository.SaveVote(vote);
        }

        private int NumberOfVotesForContent(long contentObjectPK, long contentTypeID)
        {
            var q = _votesRepository.Votes.Where(
                vote => vote.ContentTypeID == contentTypeID &&
                        vote.ContentObjectPK == contentObjectPK).
                Select(vote => vote.VoteValue);
            return q.Count() > 0 ? q.Sum() : 0;
        }

        private bool MemberHasVotedForContent(long contentObjectPK, long contentTypeID, long memberID)
        {
            return _votesRepository.Votes.Count(vote =>
                                                vote.MemberID == memberID && vote.ContentTypeID == contentTypeID &&
                                                vote.ContentObjectPK == contentObjectPK) != 0;
        }

        private static Vote BuildVoteForContentType(long contentObjectPK, long contentTypeID, long memberID,
                                                    int voteValue)
        {
            return new Vote
                       {
                           MemberID = memberID,
                           ContentTypeID = contentTypeID,
                           ContentObjectPK = contentObjectPK,
                           VoteValue = voteValue
                       };
        }
    }
}