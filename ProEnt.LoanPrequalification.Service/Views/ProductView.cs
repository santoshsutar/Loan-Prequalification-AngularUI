using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace ProEnt.LoanPrequalification.Service.Views
{
    [DataContract]
    public class ProductView
    {
        private string _id;
        private string _name;        
        private float _intrestRate;
        private float _maximumLTV;
        private float _maximumLoan;
        private int _maximumLoanTerm;

        [DataMember]
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }
    
        [DataMember]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [DataMember]
        public float InterestRate
        {
            get { return _intrestRate; }
            set { _intrestRate = value; }
        }

        [DataMember]
        public float MaximumLTV
        {
            get { return _maximumLTV; }
            set { _maximumLTV = value; }
        }

        [DataMember]
        public float MaximumLoan
        {
            get { return _maximumLoan; }
            set { _maximumLoan = value; }
        }

        [DataMember]
        public int MaximumLoanTerm
        {
            get { return _maximumLoanTerm; }
            set { _maximumLoanTerm = value; }
        }
    }
}
