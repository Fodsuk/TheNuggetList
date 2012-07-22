#region

using System;
using System.Web.Mvc;
using TheNuggetList.Domain.Services;
using TheNuggetList.WebUI.ViewModels;

#endregion

namespace TheNuggetList.WebUI.Controllers
{
    public class NuggetsController : Controller
    {
        private readonly IMemberAuthenticationService _memberAuthenticationService;
        private readonly INuggetsService _nuggetService;
        private readonly ITagsService _tagsService;

        public NuggetsController(IServiceLocator serviceLocator)
        {
            _nuggetService = serviceLocator.Get<INuggetsService>();
            _memberAuthenticationService = serviceLocator.Get<IMemberAuthenticationService>();
            _tagsService = serviceLocator.Get<ITagsService>();
        }

        public ActionResult ListNuggets()
        {
            var pageNumber = string.IsNullOrEmpty(Request.QueryString["page"])
                                 ? 1
                                 : Convert.ToInt32(Request.QueryString["page"]);

            var nuggets = _nuggetService.GetPagedNuggets(pageNumber, 10, 4);

            return View(nuggets);
        }

      

        public ActionResult Index(int id)
        {
            var nugget = _nuggetService.GetNuggetByID(id);
            var tags = _tagsService.GetTagsForContentType(nugget);

            ViewBag.Tags = tags;

            return View(new NuggetViewModel(nugget));
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(NuggetViewModel viewModel, string Tags)
        {
            if (ModelState.IsValid)
            {
                if (_memberAuthenticationService.LoggedIn)
                {
                    var newNugget = viewModel.BuildNugget();
                    newNugget.MemberID = _memberAuthenticationService.LoggedInMember.ID;

                    _nuggetService.SaveNugget(newNugget);

                    _tagsService.AssignTagsByNameToContentType(Tags, newNugget);

                    return RedirectToAction("Index", new {id = newNugget.ID});
                }
                else
                {
                    ModelState.AddModelError("", "You must be logged in to post a nugget");
                }
            }

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var nugget = _nuggetService.GetNuggetByID(id);
            return View(new NuggetViewModel(nugget));
        }

        [HttpPost]
        public ActionResult Edit(int id, NuggetViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var nugget = _nuggetService.GetNuggetByID(id);
                nugget.Description = viewModel.Description;
                nugget.Title = viewModel.Title;
                _nuggetService.SaveNugget(nugget);

                return RedirectToAction("Index", new {id = nugget.ID});
            }
            return View(viewModel);
        }
    }
}