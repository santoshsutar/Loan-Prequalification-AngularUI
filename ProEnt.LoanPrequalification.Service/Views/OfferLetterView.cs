using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ProEnt.LoanPrequalification.Service.Views
{
    public class OfferLetterView
    {
        private string _recipientName;        
        private string _recipientStreet;
        private string _recipientTown;
        private string _recipientCity;
        private string _recipientPostCode;
        private string _recipient2Name;
        private string _recipient2Street;
        private string _recipient2Town;
        private string _recipient2City;
        private string _recipient2PostCode;
        private string _loanApplicationId;
        private DateTime _expirationDate;
        private int _loanAmount;
        private float _interestRate;
        private int _loanTerm;
        private bool _hasSecondBorrower;

        [DataMember]
        public string RecipientName
        {
            get { return _recipientName; }
            set { _recipientName = value; }
        }

        [DataMember]
        public string RecipientStreet
        {
            get { return _recipientStreet; }
            set { _recipientStreet = value; }
        }

        [DataMember]
        public string RecipientTown
        {
            get { return _recipientTown; }
            set { _recipientTown = value; }
        }

        [DataMember]
        public string RecipientCity
        {
            get { return _recipientCity; }
            set { _recipientCity = value; }
        }

        [DataMember]
        public string RecipientPostCode
        {
            get { return _recipientPostCode; }
            set { _recipientPostCode = value; }
        }

        [DataMember]
        public string Recipient2Name
        {
            get { return _recipient2Name; }
            set { _recipient2Name = value; }
        }

        [DataMember]
        public string Recipient2Street
        {
            get { return _recipient2Street; }
            set { _recipient2Street = value; }
        }

        [DataMember]
        public string Recipient2Town
        {
            get { return _recipient2Town; }
            set { _recipient2Town = value; }
        }

        [DataMember]
        public string Recipient2City
        {
            get { return _recipient2City; }
            set { _recipient2City = value; }
        }

        [DataMember]
        public string Recipient2PostCode
        {
            get { return _recipient2PostCode; }
            set { _recipient2PostCode = value; }
        }

        [DataMember]
        public string LoanApplicationId
        {
            get { return _loanApplicationId; }
            set { _loanApplicationId = value; }
        }

        [DataMember]
        public float InterestRate
        {
            get { return _interestRate; }
            set { _interestRate = value; }
        }

        [DataMember]
        public int LoanAmount
        {
            get { return _loanAmount; }
            set { _loanAmount = value; }
        }

        [DataMember]
        public DateTime ExpirationDate
        {
            get { return _expirationDate; }
            set { _expirationDate = value; }
        }

        [DataMember]
        public int LoanTerm
        {
            get { return _loanTerm; }
            set { _loanTerm = value; }
        }

        [DataMember]
        public bool HasSecondBorrower
        {
            get { return _hasSecondBorrower; }
            set { _hasSecondBorrower = value; }
        }        
    }
}
