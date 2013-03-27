using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using System.Threading;
using ChatCore;
using Ninject;
using Me.WLF.IDAL;
using DomainCore;

namespace BotChatService
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Thread t = new Thread(() =>
                {
                    while (true)
                    {
                        IUserRepositary repo = new UserRepositaryByDB();
                        int i = repo.List().Count;
                        Thread.Sleep(60000);
                    }

                });
            t.IsBackground = true;
            t.Start();
        }
    }
}
