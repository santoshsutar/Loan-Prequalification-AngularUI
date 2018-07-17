using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ProEnt.LoanPrequalification.Service.Views
{
    public class AssetView
    {
        private float _balance;
        private string _accountNumber;
        private string _description;

        [DataMember]
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        [DataMember]
        public string AccountNumber
        {
            get { return _accountNumber; }
            set { _accountNumber = value; }
        }

        [DataMember]
        public float Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }
    }
}
