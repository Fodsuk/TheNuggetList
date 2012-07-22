#region

using System.Web.Mvc;
using TheNuggetList.Domain.Services;
using TheNuggetList.Domain.Entities;
using TheNuggetList.Domain.Util.Paging;
using System;

#endregion

namespace TheNuggetList.WebUI.Controllers
{
	public class AchievementsController : Controller
    {
		private readonly IAchievementsService _achievementsService;

		public AchievementsController(IServiceLocator serviceLocator)
        {
			_achievementsService = serviceLocator.Get<IAchievementsService>();
        }

		public ActionResult Index()
		{
			int pageNumber = string.IsNullOrEmpty(Request.QueryString["page"])
                                 ? 1
                                 : Convert.ToInt32(Request.QueryString["page"]);

			PagedList<Achievement> achievements = _achievementsService.GetPagedAchievements(pageNumber, 10, 4);

			return View(achievements);
		}
    }
}