using System;
using System.Collections.Generic;
using System.Text;

namespace ProEnt.LoanPrequalification.Model.LoanApplications
{
    public class Offer
    {
        private DateTime _expirationDate;
        private int _loanAmount;
        private float _interestRate;                
        private int _loanTerm;

        public Offer()
        { }

        public Offer(int loanAmount, int loanTerm, float interestRate, DateTime expirationDate)
        {
            _loanAmount = loanAmount;
            _loanTerm = loanTerm;
            _interestRate = interestRate;
            _expirationDate = expirationDate;
        
            if (GetBrokenRules().Count > 0)
            {
                throw new Exception(String.Format("The offer is trying to be created with invalid data.{0}", GetBrokenRulesToString()));
            }
        }
      
        public float InterestRate
        {
            get { return _interestRate; }            
        }

        public int LoanAmount
        {
            get { return _loanAmount; }            
        }

        public DateTime ExpirationDate
        {
            get { return _expirationDate; }            
        }

        public int LoanTerm
        {
            get { return _loanTerm; }            
        }

        public bool HasExpired()
        {
            return ExpirationDate < DateTime.Now.AddMonths(-6);
        }
        
        private string GetBrokenRulesToString()
        {
            StringBuilder sbBrokenRules = new StringBuilder();

            foreach (BrokenBusinessRule br in GetBrokenRules())
            {
                sbBrokenRules.Append(br.Rule);
            }

            return sbBrokenRules.ToString();
        }

        public List<BrokenBusinessRule> GetBrokenRules()
        {
            List<BrokenBusinessRule> brokenRules = new List<BrokenBusinessRule>();

            if (InterestRate <= 0)
                brokenRules.Add(new BrokenBusinessRule("InterestRate", "An Offer must have an interest rate greater than zero."));

            if (LoanAmount <= 0)
                brokenRules.Add(new BrokenBusinessRule("LoanAmount", "An Offer must have a Loan Amount greater than zero."));

            if (LoanAmount <= 0)
                brokenRules.Add(new BrokenBusinessRule("LoanTerm", "An Offer must have a Loan Term greater than zero."));

            return brokenRules;
        }
    }
}
