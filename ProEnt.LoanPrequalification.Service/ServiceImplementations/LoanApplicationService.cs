using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProEnt.LoanPrequalification.Model;
using ProEnt.LoanPrequalification.Model.LoanApplications;
using ProEnt.LoanPrequalification.Model.Products; 
using ProEnt.LoanPrequalification.Service.Messages;
using ProEnt.LoanPrequalification.Service.Views;
using ProEnt.LoanPrequalification.Service.ServiceContracts;

namespace ProEnt.LoanPrequalification.Service.ServiceImplementations
{
    public class LoanApplicationService : ILoanApplicationService 
    {
        private Model.LoanApplications.LoanApplicationService _loanApplicationService;
        private Model.Products.ProductService _productService;

        public LoanApplicationService(Model.LoanApplications.LoanApplicationService loanApplicationService, Model.Products.ProductService productService)
        {
            _loanApplicationService = loanApplicationService;
            _productService = productService;
        }

        public LoanApplicationListResponse GetAllLoanApplications()
        {            
            List<LoanApplication> loanApplications = _loanApplicationService.FindAll();

            LoanApplicationListResponse response = new LoanApplicationListResponse();
            List<LoanApplicationSummaryView> loanApplicationViews = new List<LoanApplicationSummaryView>();

            foreach (LoanApplication loanApp in loanApplications)
            {
                loanApplicationViews.Add(Mapper.BuildLoanApplicationSummaryViewFrom(loanApp));               
            }

            response.LoanApplications = loanApplicationViews;
            response.Success = true;

            return response;
        }

        public LoanApplicationGetByIdResponse GetLoanApplicationById(LoanApplicationGetByIdRequest loanApplicationGetByIdRequest)
        {
            LoanApplicationGetByIdResponse response = new LoanApplicationGetByIdResponse();

            if (Helper.IsGuid(  loanApplicationGetByIdRequest.Id))
            {
                LoanApplication loanApp = _loanApplicationService.FindLoanApplicationBy(new Guid(loanApplicationGetByIdRequest.Id));
                
                LoanApplicationDetailView loanApplicationDetailView;

                loanApplicationDetailView = Mapper.CreateLoanApplicationDetailViewFrom(loanApp);

                response.LoanApplication = loanApplicationDetailView;
                response.Success = true;
            }
            else
            {
                response.Message = string.Format("'{0}' is not a valid loan application id", loanApplicationGetByIdRequest.Id);
                response.Success = false;
            }
            

            return response;
        }

        public LoanApplicationCreateResponse SubmitLoanApplication(LoanApplicationCreateRequest LoanApplicationCreateRequest)
        {
            LoanApplicationCreateResponse response = new LoanApplicationCreateResponse();

            try
            {
                LoanApplication loanApplication = Mapper.CreateLoanApplicationFrom(LoanApplicationCreateRequest.LoanApplicationView);
                Product product = _productService.FindBy(new Guid(LoanApplicationCreateRequest.LoanApplicationView.ProductId));
                loanApplication.Product = product;

                if(loanApplication.GetBrokenRules().Count == 0)  
                {
                    _loanApplicationService.SubmitForPrequalification(loanApplication);
                    response.LoanApplicationId = loanApplication.Id.ToString();
                    response.Success = true;
                }
                else
                {
                    response.Success = false;
                    response.Message = ErrorHelper.GetBrokenRulesToStringFor(loanApplication.GetBrokenRules()); 
                }
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
            }

            return response;
        }

        public OfferLetterGetByIdResponse GetOfferLetterForLoanApplicationById(OfferLetterGetByIdRequest offerLetterGetByIdRequest)
        {
            OfferLetterGetByIdResponse response = new OfferLetterGetByIdResponse();

            if (Helper.IsGuid(offerLetterGetByIdRequest.Id))
            {
                LoanApplication loanApp = _loanApplicationService.FindLoanApplicationBy(new Guid(offerLetterGetByIdRequest.Id));

                if (loanApp.HasOffer() == true)
                {
                    response.Success = true;
                    response.OfferLetter = Mapper.CreateOfferLetterViewFrom(loanApp);
                }
                else
                {
                    response.Success = false;
                }
            }
            else
            {
                response.Message = string.Format("'{0}' is not a valid loan application id", offerLetterGetByIdRequest.Id);
                response.Success = false;
            }

            return response;
        }        
    }
}
