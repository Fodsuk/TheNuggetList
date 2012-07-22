#region

using TheNuggetList.Domain.Entities;

#endregion

namespace TheNuggetList.Domain.Services
{
    public interface IMemberAuthenticationService
    {
        Member LoggedInMember { get; }

        bool LoggedIn { get; }

        bool LogInMember(string emailAddress, string password);

        void LogOutMember();

        bool EmailAddressExists(string emailAddress);

        bool DisplayNameExists(string displayName);

        void RegisterMember(Member member);

		bool ConfirmPasswordForLoggedInMember(string password);

		void SetLoggedInMemberPassword(string password);
    }
}