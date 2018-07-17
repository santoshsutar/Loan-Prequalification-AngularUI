using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.Mvc;
using StructureMap;
using System.Web.Routing;

namespace ProEnt.LoanPrequalification.UI.MVC.Controllers
{
    public class IoCControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType==null)
            {
                return null;
            }
            return ObjectFactory.GetInstance(controllerType) as IController;
        }      
    } 
}
