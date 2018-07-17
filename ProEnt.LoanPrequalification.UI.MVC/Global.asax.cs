using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ProEnt.LoanPrequalification.UI.MVC.Controllers;
using ProEnt.LoanPrequalification.UI.MVC;
using System.Web.Http;
using System.Web.Http.Filters;

namespace WroxProf.LoanApproval.UI.MVC
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapHttpRoute(name: "DefaultApi",
routeTemplate: "api/{controller}/{action}/{id}",
defaults: new { id = RouteParameter.Optional });

            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);

            ControllerBuilder.Current.SetControllerFactory(new IoCControllerFactory());

            BootStrapper.ConfigureStructureMap();
        }
    }
    public class AllowCrossSiteJsonAttribute : System.Web.Http.Filters.ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Response != null)
            {
                // var origin = actionExecutedContext.Request.Headers["Origin"];
                actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:4200");
                actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Methods", "POST, GET, OPTIONS, PUT");
                actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Credentials", "true");
                actionExecutedContext.Response.Headers.Add("SupportsCredentials", "true");
                // actionExecutedContext.Response.Headers.Add("Content-Type", "Set-Cookie");
                //actionExecutedContext.Response.Headers.
            }

            base.OnActionExecuted(actionExecutedContext);
        }
    }
}