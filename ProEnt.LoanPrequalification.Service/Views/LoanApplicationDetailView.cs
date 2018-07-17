using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ProEnt.LoanPrequalification.Service.Views
{
    public class LoanApplicationDetailView
    {
        private string _id;
        private int _deposit;
        private string _status;
        private List<BorrowerView> _borrowers = new List<BorrowerView>() ;
        private string _productName;                
        private int _propertyValue;
        private int _loanAmount;
        private int _loanTerm;
        private bool _hasOffer;
        private string _productId;
        private List<AssetView> _assets = new List<AssetView>();                
        private List<DebtView> _debts = new List<DebtView>();                
        private string _propertyStreet;
        private string _propertyTown;
        private string _propertyCity;
        private string _propertyPostCode;        

        [DataMember]
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        [DataMember]
        public string PropertyStreet
        {
            get { return _propertyStreet; }
            set { _propertyStreet = value; }
        }

        [DataMember]
        public string PropertyTown
        {
            get { return _propertyTown; }
            set { _propertyTown = value; }
        }

        [DataMember]
        public string PropertyCity
        {
            get { return _propertyCity; }
            set { _propertyCity = value; }
        }

        [DataMember]
        public string PropertyPostCode
        {
            get { return _propertyPostCode; }
            set { _propertyPostCode = value; }
        }

        [DataMember]
        public int Deposit
        {
            get { return _deposit; }
            set { _deposit = value; }
        }

        [DataMember]
        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        [DataMember]
        public int PropertyValue
        {
            get { return _propertyValue; }
            set { _propertyValue = value; }
        }

        [DataMember]
        public int LoanAmount
        {
            get { return _loanAmount; }
            set { _loanAmount = value; }
        }

        [DataMember]
        public int LoanTerm
        {
            get { return _loanTerm; }
            set { _loanTerm = value; }
        }

        [DataMember]
        public bool HasOffer
        {
            get { return _hasOffer; }
            set { _hasOffer = value; }
        }

        [DataMember]
        public string ProductName
        {
            get { return _productName; }
            set { _productName = value; }
        }

        [DataMember]
        public List<BorrowerView> Borrowers
        {
            get { return _borrowers; }
            set { _borrowers = value; }
        }
       
        [DataMember]
        public List<AssetView> Assets
        {
            get { return _assets; }
            set { _assets = value; }
        }
        
        [DataMember]
        public List<DebtView> Debts
        {
            get { return _debts; }
            set { _debts = value; }
        }
        
    }
}
