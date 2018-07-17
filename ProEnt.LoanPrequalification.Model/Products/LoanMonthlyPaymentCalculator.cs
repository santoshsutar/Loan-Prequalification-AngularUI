using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProEnt.LoanPrequalification.Model.Products
{
    public class LoanMonthlyPaymentCalculator
    {
        public float LoanPaymentsPerMonthFor(float LoanAmount, float InterestRate, int LoanTerm)
        {
            double int_trm = Math.Pow(1 + InterestRate / 1200, LoanTerm * 12);
            double mrt_year = (LoanAmount * InterestRate * int_trm) / (1200 * (int_trm - 1));
            double payments = (mrt_year * 12 / 12);
            double p = Math.Round(payments * 100) / 100;
            return (float)Math.Round(p * 1, 2);
        }
    }
}
