#region

using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using TheNuggetList.Domain.Entities;
using TheNuggetList.Domain.Repositories;
using EventAggregator;
using TheNuggetList.Domain.Events;
using System.Configuration;

#endregion

namespace TheNuggetList.Domain.Services
{
    public class MemberAuthenticationService : IMemberAuthenticationService
    {
        private const string LoggedInMemberSessionKey = "_loggedInMember";
		private Member _repositoryLoggedInMember;
		private IEventAggregator _eventAggregator;

        public MemberAuthenticationService(IServiceLocator serviceLocator)
        {
            MembersRepository = serviceLocator.Get<IMembersRepository>();
			_eventAggregator = serviceLocator.Get<IEventAggregator>();
            PasswordSalt = ConfigurationManager.AppSettings["passwordSalt"];
        }

        private IMembersRepository MembersRepository { get; set; }

        private string PasswordSalt { get; set; }

		private Member repositoryLoggedInMember
		{
			get
			{
				if (_repositoryLoggedInMember == null)
				{
					Member loggedInMember = LoggedInMember;

					if (loggedInMember != null)
					{
						_repositoryLoggedInMember = MembersRepository.Members.FirstOrDefault(x => x.ID == loggedInMember.ID);
					}
				}

				return _repositoryLoggedInMember;
			}
		}

		private void refreshLoggedInMember()
		{
			LoggedInMember = repositoryLoggedInMember;
		}

		private String EncryptPassword(String nakedPassword)
		{
			var salt = PasswordSalt;

			var bytes = Encoding.UTF8.GetBytes(nakedPassword + salt + nakedPassword);

			var hash = new SHA1CryptoServiceProvider();

			var resultBytes = hash.ComputeHash(bytes);

			var hex = new StringBuilder(resultBytes.Length * 2);

			foreach (var b in resultBytes)
			{
				hex.AppendFormat("{0:x2}", b);
			}

			return hex.ToString();
		}

		public bool LogInMember(Member member)
		{
			if (member != null)
			{
				LoggedInMember = member;
				return true;
			}

			return false;
		}

        #region IMemberAuthenticationService Members

        public Member LoggedInMember
        {
            get { return (Member) HttpContext.Current.Session[LoggedInMemberSessionKey]; }
            private set { HttpContext.Current.Session[LoggedInMemberSessionKey] = value; }
        }

        public bool LoggedIn
        {
            get { return LoggedInMember != null; }
        }

        public bool LogInMember(string emailAddress, string password)
        {
            password = EncryptPassword(password);

            var member = MembersRepository.GetMemberForLogin(emailAddress, password);

            return LogInMember(member);
        }

        public void LogOutMember()
        {
            HttpContext.Current.Session.Contents.Remove(LoggedInMemberSessionKey);
        }

        public bool EmailAddressExists(string emailAddress)
        {
            return MembersRepository.Members.Any(x => x.EmailAddress == emailAddress);
        }

        public bool DisplayNameExists(string displayName)
        {
            return MembersRepository.Members.Any(x => x.DisplayName == displayName);
        }

        public void RegisterMember(Member member)
        {
            member.Password = EncryptPassword(member.Password);

            MembersRepository.SaveMember(member);

            LogInMember(member);

			_eventAggregator.SendMessage(new MemberRegisteredEvent(member));
        }

		public bool ConfirmPasswordForLoggedInMember(string password)
		{
			password = EncryptPassword(password);

			return LoggedInMember.Password == password;
		}

		public void SetLoggedInMemberPassword(string password)
		{
			Member loggedInMember = repositoryLoggedInMember;

			password = EncryptPassword(password);
			loggedInMember.Password = password;
			MembersRepository.SaveMember(loggedInMember);

			refreshLoggedInMember();
		}

        #endregion
	}
}