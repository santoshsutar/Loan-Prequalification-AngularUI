using System;
using System.Collections.Generic;
using ProEnt.LoanPrequalification.Model.LoanApplications;

namespace ProEnt.LoanPrequalification.Model.Products
{
    public class Product
    {
        private Guid _id;
        private string _name;
        private float _intrestRate;
        private float _maximumLTV;
        private float _maximumLoan;
        private int _maximumLoanTerm;
        private ProductIsAvailableSpecification _productIsAvailable;

        public Product()
        {
            _productIsAvailable = new ProductIsAvailableSpecification(this, new LoanMonthlyPaymentCalculator());
        }
        
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public float InterestRate
        {
            get { return _intrestRate; }
            set { _intrestRate = value; }
        }

        public float MaximumLTV
        {
            get { return _maximumLTV; }
            set { _maximumLTV = value; }
        }

        public float MaximumLoan
        {
            get { return _maximumLoan; }
            set { _maximumLoan = value; }
        }

        public int MaximumLoanTerm
        {
            get { return _maximumLoanTerm; }
            set { _maximumLoanTerm = value; }
        }

        public bool IsAvailableFor(LoanApplication loanApplication)
        {
            return _productIsAvailable.IsSatisfiedBy(loanApplication);
        }
      
        public List<BrokenBusinessRule> GetBrokenRules()
        {
            List<BrokenBusinessRule> brokenRules = new List<BrokenBusinessRule>();

            if (String.IsNullOrEmpty(Name))
                brokenRules.Add(new BrokenBusinessRule("Name", "A product must have a name."));

            if (!IsValidInterestRate())
                brokenRules.Add(new BrokenBusinessRule("InterestRate", " product's interest rate must be a multiple of 1/4 percent."));

            if (MaximumLoanTerm <= 0)
                brokenRules.Add(new BrokenBusinessRule("MaximumLoanTerm", " Maximum Loan Term must be a positive number."));

            if (MaximumLoan <= 0)
                brokenRules.Add(new BrokenBusinessRule("MaximumLoan", " Maximum Loan must be a positive number."));

            if (MaximumLTV <= 0)
                brokenRules.Add(new BrokenBusinessRule("MaximumLTV", " Maximum Loan to Value must be a positive number."));            

            return brokenRules;
        }

        private bool IsValidInterestRate()
        {
            bool valid = true;

            if (InterestRate > 0)
            {
                if (InterestRate % 0.125 != 0)
                {
                    valid = false;
                }
            }
            else
            {
                valid = false;
            }

            return valid;
        }
    }
}
