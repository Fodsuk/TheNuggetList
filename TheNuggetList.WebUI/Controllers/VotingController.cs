using System.Web.Mvc;
using TheNuggetList.Domain.Repositories;
using TheNuggetList.Domain.Services;
using TheNuggetList.WebUI.ViewModels.Votes;


namespace TheNuggetList.WebUI.Controllers
{
    public class VotingController : Controller
    {
        private readonly IContentTypesRepository _contentTypeRepository;
        private readonly IVotingService _votingService;

        public VotingController(IServiceLocator serviceLocator)
        {
            _votingService = serviceLocator.Get<IVotingService>();
            _contentTypeRepository = serviceLocator.Get<IContentTypesRepository>();
        }

        [ChildActionOnly]
        [HttpGet]
        public ActionResult Votes(long contentObjectPK, string contentTypeName)
        {
            var model = new VoteViewModel
                            {
                                VoteCount = _votingService.NumberOfVotesForContent(contentObjectPK, contentTypeName),
                                ContentTypeName = contentTypeName,
                                ContentTypePK = contentObjectPK
                            };

            return PartialView(model);
        }

        public ActionResult UpVote(string contentType, long pk)
        {
            _votingService.UpVoteContent(pk, contentType);
            return new RedirectResult(Request.QueryString["ReturnUrl"]);
        }

        public ActionResult DownVote(string contentType, long pk)
        {
            _votingService.DownVoteContent(pk, contentType);
            return new RedirectResult(Request.QueryString["ReturnUrl"]);
        }

        public JsonResult UpVoteAjax(string contentType, long pk)
        {
            _votingService.UpVoteContent(pk, contentType);
            return Json(new {count = _votingService.NumberOfVotesForContent(pk, contentType)},
                        JsonRequestBehavior.AllowGet);
        }

        public JsonResult DownVoteAjax(string contentType, long pk)
        {
            _votingService.DownVoteContent(pk, contentType);
            return Json(new {count = _votingService.NumberOfVotesForContent(pk, contentType)},
                        JsonRequestBehavior.AllowGet);
        }
    }
}