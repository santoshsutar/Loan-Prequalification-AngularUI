using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ProEnt.LoanPrequalification.Service.Views
{
    public class LoanApplicationCreateView
    {
        private string _id;
        private int _deposit;
        private string _status;
        private BorrowerView _borrower1;
        private BorrowerView _borrower2;
        //private IAddress _propertyAddress;
        //private Products.Product _product;
        //private Offer _offer;
        private int _propertyValue;
        private int _loanAmount;
        private int _loanTerm;
        private bool _hasOffer;
        private string _productId;
        private AssetView _asset1;
        private AssetView _asset2;
        private AssetView _asset3;
        private DebtView _debt1;
        private DebtView _debt2;
        private DebtView _debt3;
        private string _propertyStreet;
        private string _propertyTown;
        private string _propertyCity;
        private string _propertyPostCode;
        private bool _hasSecondBorrower;

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
        public string ProductId
        {
            get { return _productId; }
            set { _productId = value; }
        }

        [DataMember]
        public BorrowerView Borrower1
        {
            get { return _borrower1; }
            set { _borrower1 = value; }
        }

        [DataMember]
        public BorrowerView Borrower2
        {
            get { return _borrower2; }
            set { _borrower2 = value; }
        }

        [DataMember]
        public AssetView Asset1
        {
            get { return _asset1; }
            set { _asset1 = value; }
        }

        [DataMember]
        public AssetView Asset2
        {
            get { return _asset2; }
            set { _asset2 = value; }
        }

        [DataMember]
        public AssetView Asset3
        {
            get { return _asset3; }
            set { _asset3 = value; }
        }

        [DataMember]
        public DebtView Debt1
        {
            get { return _debt1; }
            set { _debt1 = value; }
        }

        [DataMember]
        public DebtView Debt2
        {
            get { return _debt2; }
            set { _debt2 = value; }
        }

        [DataMember]
        public DebtView Debt3
        {
            get { return _debt3; }
            set { _debt3 = value; }
        }

        [DataMember]
        public bool HasSecondBorrower
        {
            get { return _hasSecondBorrower; }
            set { _hasSecondBorrower = value; }
        }
        
    }
}
