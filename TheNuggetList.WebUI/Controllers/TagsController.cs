#region

using System.Linq;
using System.Web.Mvc;
using TheNuggetList.Domain.Services;
using TheNuggetListUtil = TheNuggetList.Domain.Util;

#endregion

namespace TheNuggetList.WebUI.Controllers
{
    public class TagsController : Controller
    {
        private readonly ITagsService _tagsService;

        public TagsController(IServiceLocator serviceLocator)
        {
            _tagsService = serviceLocator.Get<ITagsService>();
        }

        public ActionResult Index(string tags)
        {
            var helper = new TheNuggetListUtil.UrlHelper();
            var tagNames = helper.SplitUrl(tags, t => t.Replace('-', ' '));

            var tagsFromNames = _tagsService.GetTagsByNames(tagNames);

            var associatedNuggets = _tagsService.GetNuggetsAssignedToTags(tagsFromNames.ToList());

            ViewBag.Tags = tagsFromNames;
            ViewBag.Nuggets = associatedNuggets;

            return View();
        }
    }
}