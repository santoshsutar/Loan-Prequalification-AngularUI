using System;
using System.Collections.Generic;
using System.Text;

namespace ProEnt.LoanPrequalification.Model.LoanApplications
{
    public class LoanApplicationService
    {
        private ILoanApplicationRepository loanApplicationRepository;

        public LoanApplicationService(ILoanApplicationRepository loanApplicationRepository)
        {
            this.loanApplicationRepository = loanApplicationRepository;
        }

        #region Loan Application WorkFlow

        /// <summary>
        ///Loan Appliction Is Submitted and Prequalfied
        /// </summary>        
        public void SubmitForPrequalification(LoanApplication loanApplication)
        {
            if (loanApplication.GetBrokenRules().Count != 0)
                throw new InvalidLoanApplicationException(String.Format("This loan is invalid and cannot be submmitted. {0}", GetBrokenRulesToStringFor(loanApplication.GetBrokenRules())));

            loanApplication.Prequalify();
            loanApplicationRepository.Save(loanApplication);

        }

        /// <summary>
        /// Retrieving an offer in principal
        /// </summary>        
        public Offer GetOfferInPrincipalFor(Guid loanApplicationId)
        {
            LoanApplication loanApp = FindLoanApplicationBy(loanApplicationId);
            return loanApp.GetOfferInPrincipal();
        }

        #endregion

        public LoanApplication FindLoanApplicationBy(Guid loanApplicationId)
        {
            LoanApplication loanApp = loanApplicationRepository.FindBy(loanApplicationId);
            if (loanApp == null)
                throw new Exception(String.Format("Cannot find a loan application with the ID '{0}'.", loanApplicationId.ToString()));

            return loanApp;
        }

        public void Save(LoanApplication loanApplication)
        {
            if (loanApplication.GetBrokenRules().Count > 0)
            {
                throw new InvalidLoanApplicationException(
                    String.Format("This loan application is invalid and cannot be saved in its present state. '{0}'", GetBrokenRulesToStringFor(loanApplication.GetBrokenRules())));
            }
            loanApplicationRepository.Save(loanApplication);
        }

        public List<LoanApplication> FindAll()
        {
            return loanApplicationRepository.FindAll();
        }

        private string GetBrokenRulesToStringFor(List<BrokenBusinessRule> brokenRules)
        {
            StringBuilder sbBrokenRules = new StringBuilder();

            foreach (BrokenBusinessRule br in brokenRules)
            {
                sbBrokenRules.AppendLine(br.Rule);
            }

            return sbBrokenRules.ToString();
        }
    }
}
