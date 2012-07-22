#region

using System.Linq;
using TheNuggetList.Domain.Entities;

#endregion

namespace TheNuggetList.Domain.Repositories
{
    public class MemberStatisticsRepository : IMemberStatisticsRepository
    {
        private readonly TheNuggetsListDbContext _dbContext;

        public MemberStatisticsRepository(TheNuggetsListDbContext context)
        {
            _dbContext = context;
        }

        #region IMemberStatisticsRepository Members

        public IQueryable<MemberStatistics> MemberStatistics
        {
            get { return _dbContext.MemberStatistics.AsQueryable(); }
        }

        public void SaveMemberStatistics(MemberStatistics memberStatistics)
        {
            _dbContext.SaveChanges();
        }

        public MemberStatistics CreateMemberStatistics(Member member)
        {
            MemberStatistics memberStatistics = new MemberStatistics() { MemberID = member.ID };
            _dbContext.MemberStatistics.Add(memberStatistics);

            return memberStatistics;
        }

        public MemberStatistics GetMemberStatisticsByMemberID(long memberID)
        {
            return _dbContext.MemberStatistics.Find(memberID);
        }

        #endregion
    }
}