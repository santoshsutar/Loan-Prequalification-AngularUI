using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ProEnt.LoanPrequalification.Model.Borrowers;
using ProEnt.LoanPrequalification.Model.Products;

namespace ProEnt.LoanPrequalification.Model.LoanApplications
{
    public class LoanApplication
    {
        private Guid _id;
        private int _deposit;
        private Status _status;
        private IList<Borrower> _borrowers = new List<Borrower>();
        private IAddress _propertyAddress;
        private Products.Product _product;
        private Offer _offer;
        private int _propertyValue;
        private int _loanAmount;
        private int _loanTerm;        
        private IList<Asset> _assets = new List<Asset>();
        private IList<Debt> _debts = new List<Debt>();

        public LoanApplication()
        {
            _borrowers = new List<Borrower>();
            _assets = new List<Asset>();
            _debts = new List<Debt>();
        }

        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int Deposit
        {
            get { return _deposit; }
            set { _deposit = value; }
        }

        public Status Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public ReadOnlyCollection<Borrower> Borrowers
        {
            get { return new ReadOnlyCollection<Borrower>(_borrowers); }
        }

        public void Add(Borrower borrower)
        {
            if (Borrowers.Count != 2)
            {
                _borrowers.Add(borrower);
            }
            else
            {
                throw new InvalidLoanApplicationException("No more than two borrowers can apply for a loan");
            }
        }

        public void Remove(Borrower borrower)
        {
            _borrowers.Remove(borrower);
        }

        public IAddress PropertyAddress
        {
            get { return _propertyAddress; }
            set { _propertyAddress = value; }
        }

        public int PropertyValue
        {
            get { return _propertyValue; }
            set { _propertyValue = value; }
        }

        public int LoanAmount
        {
            get { return _loanAmount; }
            set { _loanAmount = value; }
        }

        public int LoanTerm
        {
            get { return _loanTerm; }
            set { _loanTerm = value; }
        }

        public Product Product
        {
            get { return _product; }
            set { _product = value; }
        }

        private Offer Offer
        {
            get { return _offer; }
        }

        public IList<Asset> Assets
        {
            get { return _assets; }
            set { _assets = value; }
        }

        public IList<Debt> Debts
        {
            get { return _debts; }
            set { _debts = value; }
        }

        public float BorrowerTotalMonthlyIncome()
        {
            float totalJoinedMonthlyIncome = 0;

            foreach (Borrower b in Borrowers)
            {
                totalJoinedMonthlyIncome += b.Employer.MonthlyIncome;
            }
            return totalJoinedMonthlyIncome;
        }

        public float BorrowerTotalMonthlyDebts()
        {
            float totalMonthlyDebt = 0;

            foreach (Debt d in Debts)
            {
                totalMonthlyDebt += d.MonthlyPayment;
            }
            return totalMonthlyDebt;

        }

        #region WorkFlow Methods

        public void Prequalify()
        {
            ThrowExceptionIfLoanAppIsInValid("Prequalification");

            if (Product.IsAvailableFor(this))
            {
                _status = Status.OfferGiven;
                GenerateOffer();
            }
            else
                _status = Status.Declined;
        }

        private void GenerateOffer()
        {
            _offer = new Offer(LoanAmount, LoanTerm, 
                               Product.InterestRate, 
                               DateTime.Now.AddMonths(6));           
        }

        public bool HasOffer()
        {
            return (Offer != null);
        }

        public bool HasOfferExpired()
        {
            if (Offer == null)
                throw new Exception("No offer has been generated");

            return Offer.HasExpired();
        }

        public Offer GetOfferInPrincipal()
        {
            if (Offer == null)
                throw new AnOfferInPrincipalHasNotBeenGenerated();

            return Offer;
        }

        private void ThrowExceptionIfLoanAppIsInValid(string Process)
        {
            if (GetBrokenRules().Count > 0)
            {
                StringBuilder sbBrokenRules = new StringBuilder();

                foreach (BrokenBusinessRule br in GetBrokenRules())
                {
                    sbBrokenRules.Append(br.Rule);
                }

                throw new InvalidLoanApplicationException(String.Format("The '{0}' process cannot be started because the loan application is in an invalid state. {1}", Process, sbBrokenRules.ToString()));
            }
        }

        #endregion

        public List<BrokenBusinessRule> GetBrokenRules()
        {
            List<BrokenBusinessRule> brokenRules = new List<BrokenBusinessRule>();

            if (Borrowers.Count == 0)
                brokenRules.Add(new BrokenBusinessRule("Borrower", "A loan application must have at least one borrower."));
            else
            {
                foreach (Borrower borrower in this.Borrowers)
                {
                    if (borrower.GetBrokenRules().Count > 0)
                    {
                        AddToBrokenRulesList(brokenRules, borrower.GetBrokenRules());
                    }
                }
            }

            if (PropertyAddress == null)
                brokenRules.Add(new BrokenBusinessRule("PropertyAddress", "A loan application must have a property address."));
            else if (PropertyAddress.GetBrokenRules().Count > 0)
            {
                AddToBrokenRulesList(brokenRules, PropertyAddress.GetBrokenRules());
            }

            if (Deposit < 0)
                brokenRules.Add(new BrokenBusinessRule("Deposit", "A deposit must be a non negative number."));

            if (PropertyValue <= 0)
                brokenRules.Add(new BrokenBusinessRule("PropertyValue", "A property must have a value gretaer than zero."));

            if (LoanAmount <= 0)
                brokenRules.Add(new BrokenBusinessRule("LoanAmount", "A loan amount must be greater than zero."));

            if (LoanTerm <= 0)
                brokenRules.Add(new BrokenBusinessRule("LoanTerm", "A loan term must be greater than zero."));

            if (Product == null)
                brokenRules.Add(new BrokenBusinessRule("Product", "A loan application must have a loan product selected."));
            else if (Product.GetBrokenRules().Count > 0)
            {
                AddToBrokenRulesList(brokenRules, Product.GetBrokenRules());
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
