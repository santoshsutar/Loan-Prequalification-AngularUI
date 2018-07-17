using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProEnt.LoanPrequalification.UI.WPF.Views
{
    public interface ISimpleMortgageCalculatorView
    {
        double LoanAmount { get; set; }
        double InterestRate { get; set; }
        int NumberOfYears { get; set; }
    }
}
