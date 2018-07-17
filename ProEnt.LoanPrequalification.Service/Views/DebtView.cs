using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ProEnt.LoanPrequalification.Service.Views
{
    public class DebtView
    {
        private string _description;
        private string _creditorName;
        private float _balanceOwed;
        private float _monthlyPayment;

        [DataMember]
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        [DataMember]
        public string CreditorName
        {
            get { return _creditorName; }
            set { _creditorName = value; }
        }

        [DataMember]
        public float BalanceOwed
        {
            get { return _balanceOwed; }
            set { _balanceOwed = value; }
        }

        [DataMember]
        public float MonthlyPayment
        {
            get { return _monthlyPayment; }
            set { _monthlyPayment = value; }
        }
       
    }
}
