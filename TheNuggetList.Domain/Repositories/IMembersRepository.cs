using System.Linq;
using TheNuggetList.Domain.Entities;

namespace TheNuggetList.Domain.Repositories
{
    public interface IMembersRepository
    {
        IQueryable<Member> Members { get; }
        void SaveMember(Member member);
        void DeleteMember(Member member);
        Member GetMemberByID(long memberID);
        Member GetMemberForLogin(string emailAddress, string password);
    }
}
