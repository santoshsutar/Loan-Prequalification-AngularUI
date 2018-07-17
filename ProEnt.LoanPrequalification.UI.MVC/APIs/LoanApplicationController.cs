using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WroxProf.LoanApproval.UI.MVC;
using StructureMap;
using ProEnt.LoanPrequalification.UI.MVC.LoanApplicationService;
using ProEnt.LoanPrequalification.UI.MVC.ProductService;

namespace ProEnt.LoanPrequalification.UI.MVC.APIs
{
    [AllowCrossSiteJson]
    public class LoanApplicationController : ApiController
    {
        private ProEnt.LoanPrequalification.UI.MVC.Controllers.LoanApplicationController loanApplicationController;
        public LoanApplicationController()
        {
            loanApplicationController = new ProEnt.LoanPrequalification.UI.MVC.Controllers.LoanApplicationController(ObjectFactory.GetInstance<ILoanApplicationService>(),
                ObjectFactory.GetInstance<IProductService>());
        }

        [System.Web.Http.HttpGet]
        public LoanApplicationSummaryView[] Index()
        {
            this.loanApplicationController.Index();
            System.Web.Mvc.ViewResult viewResult = (System.Web.Mvc.ViewResult)loanApplicationController.Index();
            LoanApplicationSummaryView[] productView = (LoanApplicationSummaryView[])viewResult.ViewData.Model;
            return productView;
        }

    }
}
