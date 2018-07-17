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
using StructureMap;
using StructureMap.Configuration.DSL;
using ProEnt.LoanPrequalification.UI.MVC.LoanApplicationService;
using ProEnt.LoanPrequalification.UI.MVC.ProductService;

namespace ProEnt.LoanPrequalification.UI.MVC
{
    public class BootStrapper
    {
        public static void ConfigureStructureMap()
        {
            // Initialize the registry
            ObjectFactory.Initialize(x =>
            {
                x.AddRegistry<ControllerRegistry>();

            });
        }   
    }

    public class ControllerRegistry : Registry
    {
        public ControllerRegistry()
        {            
            ForRequestedType<ILoanApplicationService>().TheDefault.Is.OfConcreteType<LoanApplicationServiceClient>()
                .WithCtorArg("endpointConfigurationName").EqualTo("WSHttpBinding_ILoanApplicationService")
                .WithCtorArg("remoteAddress").EqualTo("http://localhost:3075/LoanApplicationService.svc");

            ForRequestedType<IProductService>().TheDefault.Is.OfConcreteType<ProductServiceClient>()
                .WithCtorArg("endpointConfigurationName").EqualTo("WSHttpBinding_IProductService")
                .WithCtorArg("remoteAddress").EqualTo("http://localhost:3075/ProductService.svc");
        }

    }
}
