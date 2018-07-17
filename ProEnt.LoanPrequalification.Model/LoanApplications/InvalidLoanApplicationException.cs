using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProEnt.LoanPrequalification.Model.LoanApplications
{
    public class InvalidLoanApplicationException : Exception
    {
        public InvalidLoanApplicationException() { }
        public InvalidLoanApplicationException(string message) : base(message) { }
    }
}
