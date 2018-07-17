using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ProEnt.LoanPrequalification.Service.ServiceContracts;
using ProEnt.LoanPrequalification.Repositories.NHibernate;
using ProEnt.LoanPrequalification.Service.Messages;
using ProEnt.LoanPrequalification.Model.LoanApplications;
using ProEnt.LoanPrequalification.Model.Borrowers;
using ProEnt.LoanPrequalification.Model.Products;
using ProEnt.LoanPrequalification.Model;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace ProEnt.LoanPrequalification.Service.WCF
{
    // NOTE: If you change the class name "LoanApplicationService" here, you must also update the reference to "LoanApplicationService" in Web.config.
    public class LoanApplicationService : ILoanApplicationService
    {        
        public LoanApplicationListResponse GetAllLoanApplications()
        {
            ServiceImplementations.LoanApplicationService loanAppService = ObjectFactory.GetInstance<ServiceImplementations.LoanApplicationService>();
            return loanAppService.GetAllLoanApplications();
        }

        public LoanApplicationCreateResponse SubmitLoanApplication(LoanApplicationCreateRequest loanApplicationCreateRequest)
        {
            ServiceImplementations.LoanApplicationService loanAppService = ObjectFactory.GetInstance<ServiceImplementations.LoanApplicationService>();
            return loanAppService.SubmitLoanApplication(loanApplicationCreateRequest);
        }
                
        public LoanApplicationGetByIdResponse GetLoanApplicationById(LoanApplicationGetByIdRequest loanApplicationGetByIdRequest)
        {
            ServiceImplementations.LoanApplicationService loanAppService = ObjectFactory.GetInstance<ServiceImplementations.LoanApplicationService>();
            return loanAppService.GetLoanApplicationById(loanApplicationGetByIdRequest);
        }

        
        public OfferLetterGetByIdResponse GetOfferLetterForLoanApplicationById(OfferLetterGetByIdRequest offerLetterGetByIdRequest)
        {
            ServiceImplementations.LoanApplicationService loanAppService = ObjectFactory.GetInstance<ServiceImplementations.LoanApplicationService>();
            return loanAppService.GetOfferLetterForLoanApplicationById(offerLetterGetByIdRequest);
        }
        
    }
}
