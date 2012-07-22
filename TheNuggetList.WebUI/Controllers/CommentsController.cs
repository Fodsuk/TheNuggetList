using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheNuggetList.Domain.Entities;
using TheNuggetList.Domain.Services;
using TheNuggetList.WebUI.ViewModels;

namespace TheNuggetList.WebUI.Controllers
{
    public class CommentsController : Controller
    {
        private const string MSG_MEMBER_NOT_LOGGED_IN =  "You need to be logged in to add a comment.";
        private const string MSG_ADDING_COMMENT_FAILED =  "Error adding the comment.";
        private const string MSG_COMMENT_LENGTH_TOO_SHORT =  "Comment length was too short.";
        private const string MSG_ADDED_COMMENT_SUCCESSFULLY =  "Successfully added the comment.";

        private readonly ICommentsService _commentService;
        private readonly IMemberAuthenticationService _memberAuthService;
        
        public CommentsController(IServiceLocator serviceLocator) {
            _commentService = serviceLocator.Get<ICommentsService>();
            _memberAuthService = serviceLocator.Get<IMemberAuthenticationService>();
        }


        [HttpGet]
        [ChildActionOnly]
        public ActionResult CommentsForContentType(long contentObjectPK, string contentTypeName)
        {
            var comments = _commentService.GetCommentsForContentType(contentObjectPK, contentTypeName).ToList();

            ViewBag.Comments = comments;
            ViewBag.ContentObjectPK = contentObjectPK;
            ViewBag.ContentTypeName = contentTypeName;
            ViewBag.RedirectUrl = Request.RawUrl;

            return PartialView();
        }
        

        [HttpPost]        
        public ActionResult AddComment(long contentObjectPK, string contentTypeName, string content)
        {
            bool success = false;
            string message;

            try
            {
                if (_memberAuthService.LoggedIn) 
                {
                    if (content.Trim().Length > 0)
                    {
                        _commentService.SaveComment(contentObjectPK, contentTypeName, content);
                        success = true;
                        message = MSG_ADDED_COMMENT_SUCCESSFULLY;
                    }
                    else
                    {
                        message = MSG_COMMENT_LENGTH_TOO_SHORT;
                    }
                }
                else
                {
                    message = MSG_MEMBER_NOT_LOGGED_IN;
                }

            }
            catch (Exception)
            {
                message = MSG_ADDING_COMMENT_FAILED;
            }
            
            if (Request.IsAjaxRequest())
            {
                return Json(new { Success = success, Message = message });
            }
            else 
            {
                return Redirect(Request.Form["RedirectUrl"]);                          
            }            
        }
        
    }
}
