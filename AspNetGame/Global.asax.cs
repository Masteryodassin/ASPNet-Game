using AspNetGame.Models;
using AspNetGame.Models.Game;
using AspNetGame.Models.Game.Timeloop;
using AspNetGame.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AspNetGame
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Initialize_Context();


        }

        protected void Application_End()
        {
            IoC.Resolve<TimeloopService>().Pause();
        }

        protected void Initialize_Context()
        {
            IoC.Register(new TimeloopService(), p => p.Resume());
        }


    }
}
