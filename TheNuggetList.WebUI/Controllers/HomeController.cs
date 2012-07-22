#region

using System.Web.Mvc;

#endregion

namespace TheNuggetList.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}