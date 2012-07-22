using System.Linq;
using TheNuggetList.Domain.Entities;

namespace TheNuggetList.Domain.Repositories
{
    public interface IMemberStatisticsRepository
    {
        IQueryable<MemberStatistics> MemberStatistics { get; }
        void SaveMemberStatistics(MemberStatistics memberStatistics);
        MemberStatistics CreateMemberStatistics(Member member);
        MemberStatistics GetMemberStatisticsByMemberID(long memberID);
    }
}
