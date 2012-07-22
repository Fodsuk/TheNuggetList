#region

using System;
using System.Web.Mvc;
using TheNuggetList.Domain.Entities;
using TheNuggetList.Domain.Services;
using TheNuggetList.WebUI.ViewModels;
using TheNuggetList.Domain.Util.Paging;

#endregion

namespace TheNuggetList.WebUI.Controllers
{
    public class MyAccountController : Controller
    {
		private readonly IMemberAuthenticationService _memberAuthenticationService;
		private readonly IAchievementsService _achievementsService;

        public MyAccountController(IServiceLocator serviceLocator)
        {
			_memberAuthenticationService = serviceLocator.Get<IMemberAuthenticationService>();
			_achievementsService = serviceLocator.Get<IAchievementsService>();
        }

        public ActionResult Index()
        {
            return View();
        }

		[HttpGet]
		public ActionResult ChangePassword()
		{
			return View();
		}

		[HttpPost]
		public ActionResult ChangePassword(ChangePasswordViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				Member loggedInMember = _memberAuthenticationService.LoggedInMember;

				bool passwordConfirmationCorrect = _memberAuthenticationService.ConfirmPasswordForLoggedInMember(viewModel.CurrentPassword);

				if (passwordConfirmationCorrect)
				{
					_memberAuthenticationService.SetLoggedInMemberPassword(viewModel.NewPassword);
					return new RedirectResult("/MyAccount/?Action=ChangedPassword");
				}
				else
				{
					ModelState.AddModelError("CurrentPassword", "Incorrect password specified");
				}
			}

			return View();
		}

		public ActionResult Achievements()
		{
			Member loggedInMember = _memberAuthenticationService.LoggedInMember;

			int pageNumber = string.IsNullOrEmpty(Request.QueryString["page"])
								 ? 1
								 : Convert.ToInt32(Request.QueryString["page"]);

			PagedList<EarnedAchievement> achievements = _achievementsService.GetPagedEarnedAchievementsForMember(loggedInMember, pageNumber, 10, 4);

			return View(achievements);
		}
    }
}