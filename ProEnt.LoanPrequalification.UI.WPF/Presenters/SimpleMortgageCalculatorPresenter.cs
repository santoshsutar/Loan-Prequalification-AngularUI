using System;
using ProEnt.LoanPrequalification.Model.Products;   
using ProEnt.LoanPrequalification.UI.WPF.Views;


namespace ProEnt.LoanPrequalification.UI.WPF.Presenters
{
    public class SimpleMortgageCalculatorPresenter
    {
        ISimpleMortgageCalculatorView _IView;
        LoanMonthlyPaymentCalculator _IMort;

        public SimpleMortgageCalculatorPresenter(ISimpleMortgageCalculatorView iview, LoanMonthlyPaymentCalculator imort)
        {
            this._IView = iview;
            this._IMort = imort;
        }

        public double GetMortgagePayment()
        {
            float loanAmount = (float)_IView.LoanAmount;
            float interestRate = (float)_IView.InterestRate;

            double monthlyPayment = _IMort.LoanPaymentsPerMonthFor(loanAmount,
                                                                   interestRate,
                                                                   _IView.NumberOfYears);
            return monthlyPayment;
        }
    }
}


