using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TweetSharp;
using System.Configuration;
using System.Web.UI;

namespace TheNuggetList.WebUI.Controllers
{
    public class TwitterController : Controller
    {

        string _customerKey;
        string _customerSecretKey;
        string _accessToken;
        string _tokenSecret;
        TwitterService _service; 

        public TwitterController()
            : base()
        {
            _customerKey = ConfigurationManager.AppSettings["TwitterConsumerKey"];
            _customerSecretKey = ConfigurationManager.AppSettings["TwitterConsumerSecret"];
            _accessToken = ConfigurationManager.AppSettings["AccessToken"];
            _tokenSecret = ConfigurationManager.AppSettings["TokenSecret"];
            _service = new TwitterService(_customerKey, _customerSecretKey);

        }

        [ChildActionOnly]
        [OutputCache(Duration=3600)]
        public ActionResult Latest()
        {      
            _service.AuthenticateWith(_accessToken, _tokenSecret);
            var tweets = _service.ListTweetsOnUserTimeline(3);
                      
            ViewBag.Tweets = tweets;

            return PartialView("_ListLatest");
        }
  
    }
}
