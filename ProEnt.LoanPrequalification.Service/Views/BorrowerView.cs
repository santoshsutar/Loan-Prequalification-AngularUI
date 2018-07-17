using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ProEnt.LoanPrequalification.Service.Views
{

    public class BorrowerView
    {        
        private int _age;
        private string _firstName;
        private string _lastName;
        private string _street;
        private string _town;
        private string _city;
        private string _postCode;
        private string _employerName;
        private int _monthlyIncome;
        private string _employerStreet;
        private string _employerTown;
        private string _employerCity;
        private string _employerPostCode;
        private string _bankAccountNumber;
        private string _bankAccountname;
        private string _bankName;
        private string _bankSortCode;
        private int _creditScore;
        private string _creditAgency;

        [DataMember]
        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        [DataMember]
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        [DataMember]
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        [DataMember]
        public string Street
        {
            get { return _street; }
            set { _street = value; }
        }

        [DataMember]
        public string Town
        {
            get { return _town; }
            set { _town = value; }
        }

        [DataMember]
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        [DataMember]
        public string PostCode
        {
            get { return _postCode; }
            set { _postCode = value; }
        }

        // Employer Details
        [DataMember]
        public string EmployerName
        {
            get { return _employerName; }
            set { _employerName = value; }
        }

         [DataMember]
        public int MonthlyIncome
        {
            get { return _monthlyIncome; }
            set { _monthlyIncome = value; }
        }

         [DataMember]
         public string EmployerStreet
         {
             get { return _employerStreet; }
             set { _employerStreet = value; }
         }

         [DataMember]
         public string EmployerTown
         {
             get { return _employerTown; }
             set { _employerTown = value; }
         }

         [DataMember]
         public string EmployerCity
         {
             get { return _employerCity; }
             set { _employerCity = value; }
         }

         [DataMember]
         public string EmployerPostCode
         {
             get { return _employerPostCode; }
             set { _employerPostCode = value; }
         }

         [DataMember]
         public string BankAccountNumber
         {
             get { return _bankAccountNumber; }
             set { _bankAccountNumber = value; }
         }

         [DataMember]
         public string BankAccountname
         {
             get { return _bankAccountname; }
             set { _bankAccountname = value; }
         }

         [DataMember]
         public string BankName
         {
             get { return _bankName; }
             set { _bankName = value; }
         }

         [DataMember]
         public string BankSortCode
         {
             get { return _bankSortCode; }
             set { _bankSortCode = value; }
         }

         [DataMember]
         public int CreditScore
         {
             get { return _creditScore; }
             set { _creditScore = value; }
         }

         [DataMember]
         public string CreditAgency
         {
             get { return _creditAgency; }
             set { _creditAgency = value; }
         }                  
    }
}
