using ProEnt.LoanPrequalification.Model.Borrowers;
using ProEnt.LoanPrequalification.Model.LoanApplications;

namespace ProEnt.LoanPrequalification.Model.Products
{
    public class ProductIsAvailableSpecification
    {
        private Product _product;
        private LoanMonthlyPaymentCalculator _loanMonthlyPaymentCalculator;

        public ProductIsAvailableSpecification(Product product, LoanMonthlyPaymentCalculator loanMonthlyPaymentCalculator)
        {
            _product = product;
            _loanMonthlyPaymentCalculator = loanMonthlyPaymentCalculator;
        }

        public bool IsSatisfiedBy(LoanApplication loanApplication)
        {
            bool PreQualifiesForProduct = true;

            if (!IsValidLoanAmount(loanApplication.LoanAmount))
                PreQualifiesForProduct = false;

            if (!PropertyValueGreaterThanLoan(loanApplication.LoanAmount, loanApplication.PropertyValue))
                PreQualifiesForProduct = false;

            if (!LoanWillCoverPropertyValue(loanApplication.LoanAmount, loanApplication.PropertyValue, loanApplication.Deposit))
                PreQualifiesForProduct = false;

            if (!WithinMaximumLTV(loanApplication.LoanAmount, loanApplication.Deposit))
                PreQualifiesForProduct = false;

            foreach (Borrower borrower in loanApplication.Borrowers)
            {
                if (!WillPayLoanOffBeforeRetirement(borrower.Age, loanApplication.LoanTerm))
                PreQualifiesForProduct = false;
            }
                        
            foreach(Borrower borrower in loanApplication.Borrowers)
            {
                if (!HasGoodEnoughCreditScore(borrower.CreditScore.Score ))
                    PreQualifiesForProduct = false;
            }

            if (!IsAffordable(loanApplication.LoanAmount, loanApplication.LoanTerm,
                             loanApplication.BorrowerTotalMonthlyIncome(),
                             loanApplication.BorrowerTotalMonthlyDebts()))
                PreQualifiesForProduct = false;

            return PreQualifiesForProduct;
        }

        public bool HasGoodEnoughCreditScore(int creditScore)
        {
            return creditScore > 650;
        }

        public bool PropertyValueGreaterThanLoan(int LoanAmount, int propertyValue)
        {
            return propertyValue > LoanAmount;
        }

        public bool IsAffordable(float loan, int term, float borrowerMonthlyIncome, float borrowerMonthlyDebt)
        {
            float TotalMonthlyDebt = TotalMonthlyDebtWithLoanPaymentsFor(loan, term, borrowerMonthlyDebt);

            return MonthlyDebtExceedsThirtyPC(borrowerMonthlyIncome, TotalMonthlyDebt);
        }

        public float TotalMonthlyDebtWithLoanPaymentsFor(float loan, int term, float borrowerMonthlyDebts)
        {
            return _loanMonthlyPaymentCalculator.LoanPaymentsPerMonthFor(loan, _product.InterestRate, term) +
                                                      borrowerMonthlyDebts;
        }

        private bool MonthlyDebtExceedsThirtyPC(float borrowerMonthlyIncome, float TotalMonthlyDebt)
        {
            decimal percentageOfIncomeSpentOnDebt = (decimal.Divide((decimal)TotalMonthlyDebt, (decimal)borrowerMonthlyIncome) * 100);

            return percentageOfIncomeSpentOnDebt < 31; // Should put this figure of 31% in a variable per product?
        }

        private bool LoanWillCoverPropertyValue(float loan, float propertyValue,
                                                 float deposit)
        {
            return loan >= (propertyValue - deposit);
        }

        private bool WithinMaximumLTV(float LoanAmount, float deposit)
        {
            return _product.MaximumLTV >= (int)(100 * (1 - deposit / (LoanAmount + deposit)));
        }

        private bool WillPayLoanOffBeforeRetirement(int borrowerAge, int term)
        {
            int retirmentAge = 65;
            int ageOfBorrowerWhenLoanPaidBack = borrowerAge + term;

            return ageOfBorrowerWhenLoanPaidBack <= retirmentAge;
        }

        private bool IsValidLoanAmount(float LoanAmount)
        {
            return LoanAmount <= _product.MaximumLoan;
        }
    }
}
