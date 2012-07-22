#region

using System.Linq;
using TheNuggetList.Domain.Entities;

#endregion

namespace TheNuggetList.Domain.Repositories
{
    public class MembersRepository : IMembersRepository
    {
        private readonly TheNuggetsListDbContext _dbContext;

        public MembersRepository(TheNuggetsListDbContext context)
        {
            _dbContext = context;
        }

        #region IMembersRepository Members

        public IQueryable<Member> Members
        {
            get { return _dbContext.Members.AsQueryable(); }
        }

        public void SaveMember(Member member)
        {
            if (member.ID == 0)
            {
                _dbContext.Members.Add(member);
            }

            _dbContext.SaveChanges();
        }

        public void DeleteMember(Member member)
        {
            _dbContext.Members.Remove(member);
        }

        public Member GetMemberByID(long memberID)
        {
            return _dbContext.Members.Find(memberID);
        }

        public Member GetMemberForLogin(string emailAddress, string password)
        {
            return Members.FirstOrDefault(m => m.EmailAddress == emailAddress && m.Password == password);
        }

        #endregion
    }
}