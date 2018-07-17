using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ProEnt.LoanPrequalification.Service.Views
{
    public class LoanApplicationSummaryView
    {
        private string _id;
        private int _loanAmount;
        private string _status;
        private bool _hasOffer;

        [DataMember]
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        [DataMember]
        public int LoanAmount
        {
            get { return _loanAmount; }
            set { _loanAmount = value; }
        }

        [DataMember]
        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        [DataMember]
        public bool HasOffer
        {
            get { return _hasOffer; }
            set { _hasOffer = value; }
        }

    }
}
