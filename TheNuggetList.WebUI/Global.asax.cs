#region

using System.Configuration;
using System.Data.Entity.Infrastructure;
using System.Web.Mvc;
using System.Web.Routing;
using TheNuggetList.WebUI.Infrastructure;
using Ninject;
using TheNuggetList.Domain.Achievements;
#endregion

namespace TheNuggetList.WebUI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }


        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "upvote",
                "voting/upvote/{contentType}/{pk}/",
                new { controller = "voting", action = "upvote"},
                new { pk = @"\d+" }
                );

            routes.MapRoute(
                "downvote",
                "voting/downvote/{contentType}/{pk}/",
                new { controller = "voting", action = "downvote" },
                new { pk = @"\d+" }
                );
            
            routes.MapRoute(
                "upvoteajax",
                "voting/upvoteajax/{contentType}/{pk}/",
                new { controller = "voting", action = "upvoteajax" },
                new { pk = @"\d+" }
                );

            routes.MapRoute(
                "downvoteajax",
                "voting/downvoteajax/{contentType}/{pk}/",
                new { controller = "voting", action = "downvoteajax" },
                new { pk = @"\d+" }
                );

            routes.MapRoute(
                "tags",
                "tags/{*tags}",
                new {controller = "Tags", action = "Index"}
                );

            routes.MapRoute(
                "nuggets", // Route name
                "nuggets/{id}", // URL with parameters
                new {controller = "Nuggets", action = "Index"}, // Parameter defaults
                new {id = @"\d+"}
                );

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new {controller = "Home", action = "Index", id = UrlParameter.Optional} // Parameter defaults
                );
        }

        protected void Application_Start()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["WebsiteDb"].ConnectionString;

            var connection = Database.DefaultConnectionFactory.CreateConnection(connectionString);

            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

			//Instantiate Ninject Nuggets Kernel
			IKernel nuggetsKernel = new NuggetsKernel(connection);
			ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(nuggetsKernel));

			RegisterEventAggregatorListeners(nuggetsKernel);

            //remove unused view engines - including aspx.
            //http://channel9.msdn.com/Series/mvcConf/mvcConf-2-Steven-Smith-Improving-ASPNET-MVC-Application-Performance
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
        }

		private void RegisterEventAggregatorListeners(IKernel nuggetsKernel)
		{
			IAchievementListenersRegistration achievementListenersRegistration = nuggetsKernel.Get<IAchievementListenersRegistration>();

			//achievementListenersRegistration.RegisterListeners();
		}
    }
}