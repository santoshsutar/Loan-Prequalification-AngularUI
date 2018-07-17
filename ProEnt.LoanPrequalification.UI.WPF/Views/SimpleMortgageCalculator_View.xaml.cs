using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProEnt.LoanPrequalification.Model.Products; 
using ProEnt.LoanPrequalification.UI.WPF.Views;
using ProEnt.LoanPrequalification.UI.WPF.Presenters;

namespace ProEnt.LoanPrequalification.UI.WPF.Views
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class SimpleMortgageCalculator_View : Window, ISimpleMortgageCalculatorView
    {

        private SimpleMortgageCalculatorPresenter _presenter;

        #region ISimpleMortgageCalculatorView Implementation
        double ISimpleMortgageCalculatorView.LoanAmount
        {
            get
            {
                return double.Parse(this.loanAmount.Text);
            }
            set { }
        }

        double ISimpleMortgageCalculatorView.InterestRate
        {
            get
            {
                return double.Parse(this.interestRate.Text);
            }
            set { }
        }

        int ISimpleMortgageCalculatorView.NumberOfYears
        {
            get
            {
                return int.Parse(this.numberOfYears.Text);
            }
            set { }
        }

        #endregion

        public SimpleMortgageCalculator_View()
        {
            InitializeComponent();
            _presenter = new SimpleMortgageCalculatorPresenter(this, new LoanMonthlyPaymentCalculator());
        }

        private void calculatePayment_Click(object sender, RoutedEventArgs e)
        {
            ExecutePaymentCalculation();
        }

        private void ExecutePaymentCalculation()
        {
            this.monthlyPayment.Content = string.Format("${0}", _presenter.GetMortgagePayment().ToString());
        }
    }
}
