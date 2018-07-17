using System;
using System.Collections.Generic;

namespace ProEnt.LoanPrequalification.Model.LoanApplications
{
    public class Debt
    {
        private Guid _id;
        private string _description;
        private string _creditorName;
        private float _balanceOwed;
        private float _monthlyPayment;
        private LoanApplication _loanApplication;

        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string CreditorName
        {
            get { return _creditorName; }
            set { _creditorName = value; }
        }

        public float BalanceOwed
        {
            get { return _balanceOwed; }
            set { _balanceOwed = value; }
        }

        public float MonthlyPayment
        {
            get { return _monthlyPayment; }
            set { _monthlyPayment = value; }
        }

        public LoanApplication LoanApplication
        {
            get { return _loanApplication; }
            set { _loanApplication = value; }
        }
            

        public List<BrokenBusinessRule> GetBrokenBusinessRules()
        {
            List<BrokenBusinessRule> brokenRules = new List<BrokenBusinessRule>();

            if (string.IsNullOrEmpty(Description))
                brokenRules.Add(new BrokenBusinessRule("Description", "You must enter a valid description for this debt."));

            if (string.IsNullOrEmpty(CreditorName))
                brokenRules.Add(new BrokenBusinessRule("CreditorName", "You must enter a valid name for the creditor."));

            if (BalanceOwed == null ||
                BalanceOwed <= 0)
                brokenRules.Add(new BrokenBusinessRule("BalanceOwed", "You must enter a valid balance for this debt. Do not use commas."));

            if (MonthlyPayment == null ||
                MonthlyPayment <= 0)
                brokenRules.Add(new BrokenBusinessRule("MonthlyPayment", "You must enter a valid monthly payment for this debt. Do not use commas."));

            return brokenRules;
        }
    }
}
