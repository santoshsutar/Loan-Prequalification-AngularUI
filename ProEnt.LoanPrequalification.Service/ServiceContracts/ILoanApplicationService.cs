using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using ProEnt.LoanPrequalification.Model.Products;
using ProEnt.LoanPrequalification.Service.Views;
using ProEnt.LoanPrequalification.Service.Messages;

namespace ProEnt.LoanPrequalification.Service.ServiceContracts
{
    [ServiceContract]
    public interface ILoanApplicationService
    {        
        [OperationContract]
        LoanApplicationListResponse GetAllLoanApplications();

        [OperationContract]
        LoanApplicationGetByIdResponse GetLoanApplicationById(LoanApplicationGetByIdRequest loanApplicationGetByIdRequest);

        [OperationContract]
        LoanApplicationCreateResponse SubmitLoanApplication(LoanApplicationCreateRequest LoanApplicationCreateRequest);

        [OperationContract]
        OfferLetterGetByIdResponse GetOfferLetterForLoanApplicationById(OfferLetterGetByIdRequest offerLetterGetByIdRequest);
    }
}
