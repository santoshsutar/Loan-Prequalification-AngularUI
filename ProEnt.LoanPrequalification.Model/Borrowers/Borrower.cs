using System;
using System.Collections.Generic;
using ProEnt.LoanPrequalification.Model.LoanApplications;

namespace ProEnt.LoanPrequalification.Model.Borrowers
{
    public class Borrower
    {
        private Guid _id;
        private int _age;
        private string _firstName;
        private string _lastName;
        private IAddress _contactAddress;
        private IBankAccount _bankAccount;
        private CreditScore _creditScore;
        private Employer _employer;
        private LoanApplication _loanApplication;

        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public LoanApplication LoanApplication
        {
            get { return _loanApplication; }
            set { _loanApplication = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public IAddress ContactAddress
        {
            get { return _contactAddress; }
            set { _contactAddress = value; }
        }

        public Employer Employer
        {
            get { return _employer; }
            set { _employer = value; }
        }

        public IBankAccount BankAccount
        {
            get { return _bankAccount; }
            set { _bankAccount = value; }
        }

        public CreditScore CreditScore
        {
            get { return _creditScore; }
            set { _creditScore = value; }
        }

        public List<BrokenBusinessRule> GetBrokenRules()
        {
            List<BrokenBusinessRule> brokenRules = new List<BrokenBusinessRule>();

            if (Age < 18)
                brokenRules.Add(new BrokenBusinessRule("Age", "A borrower must be over 18 years of age"));

            if (String.IsNullOrEmpty(FirstName))
                brokenRules.Add(new BrokenBusinessRule("FirstName", "A borrower must have a first name"));

            if (String.IsNullOrEmpty(LastName))
                brokenRules.Add(new BrokenBusinessRule("LastName", "A borrower must have a last name"));

            if (CreditScore == null)
                brokenRules.Add(new BrokenBusinessRule("CreditScore", "A borrower must have a credit score"));
            else if (CreditScore.GetBrokenRules().Count > 0)
            {
                AddToBrokenRulesList(brokenRules, CreditScore.GetBrokenRules());
            }

            if (BankAccount == null)
                brokenRules.Add(new BrokenBusinessRule("BankAccount", "A borrower must have a bank account defined"));
            else if (BankAccount.GetBrokenRules().Count > 0)
            {
                AddToBrokenRulesList(brokenRules, BankAccount.GetBrokenRules());
            }

            if (Employer == null)
                brokenRules.Add(new BrokenBusinessRule("Employer", "A borrower must have an employer."));
            else if (Employer.GetBrokenRules().Count > 0)
            {
                AddToBrokenRulesList(brokenRules, Employer.GetBrokenRules());
            }

            if (ContactAddress == null)
                brokenRules.Add(new BrokenBusinessRule("ContactAddress", "A borrower must have a bank account defined."));
            else if (ContactAddress.GetBrokenRules().Count > 0)
            {
                AddToBrokenRulesList(brokenRules, ContactAddress.GetBrokenRules());
            }

            return brokenRules;
        }

        private void AddToBrokenRulesList(List<BrokenBusinessRule> currentBrokenRules, List<BrokenBusinessRule> brokenRulesToAdd)
        {
            foreach (BrokenBusinessRule brokenRule in brokenRulesToAdd)
            {
                currentBrokenRules.Add(brokenRule);
            }
        }
    }
}
