using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProEnt.LoanPrequalification.Model.Borrowers
{
    public class BorrowerService
    {
        private IBorrowerRepository borrowerRepository;

        public BorrowerService(IBorrowerRepository borrowerRepository)
        {
            this.borrowerRepository = borrowerRepository;
        }


        public Borrower FindLoanApplicationBy(Guid borrowerId)
        {
            Borrower borrower = borrowerRepository.FindBy(borrowerId);
            if (borrower == null)
                throw new Exception(String.Format("Cannot find a borrower with the ID '{0}'.", borrowerId.ToString()));

            return borrower;
        }

        public void Save(Borrower borrower)
        {
            if (borrower.GetBrokenRules().Count > 0)
            {
                throw new ArgumentException(
                    String.Format("This borrower is invalid and cannot be saved in its present state. '{0}'", GetBrokenRulesToStringFor(borrower.GetBrokenRules())));
            }
            borrowerRepository.Save(borrower);
        }

        public List<Borrower> FindAll()
        {
            return borrowerRepository.FindAll();
        }

        private string GetBrokenRulesToStringFor(List<BrokenBusinessRule> brokenRules)
        {
            StringBuilder sbBrokenRules = new StringBuilder();

            foreach (BrokenBusinessRule br in brokenRules)
            {
                sbBrokenRules.Append(br.Rule);
            }

            return sbBrokenRules.ToString();
        }
    }
}
