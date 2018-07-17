using System;
using NUnit.Framework;
using ProEnt.LoanPrequalification.Model;
using ProEnt.LoanPrequalification.Model.Borrowers;
using ProEnt.LoanPrequalification.Model.LoanApplications;
using ProEnt.LoanPrequalification.Model.Products;
using ProEnt.LoanPrequalification.Tests.Stubs;

namespace ProEnt.LoanPrequalification.Tests
{
    [TestFixture]
    public class LoanApplicationTests
    {
        #region Prequalification Tests

        [Test]
        [ExpectedException(typeof(InvalidLoanApplicationException))]
        public void A_Loan_Application_Will_Throw_An_Error_If_It_Is_In_An_Invalid_State_When_Prequalifiying()
        {
            LoanApplication loanApp = new LoanApplication();

            loanApp.Prequalify();
        }

        [Test]
        public void A_Loan_Applications_Status_Will_Change_To_Declined_If_Valid_But_Does_Not_Pass_Prequalification()
        {
            LoanApplication loanApp = CreateAValidLoanApplicationAwaitingPrequalification();

            // Ensure the loan applicaiton will not pass prequalification by            
            // altering the borrowers monhtly salary
            IAddress exisitngAddress = loanApp.Borrowers[0].Employer.Address;
            Employer emp = new Employer(100, exisitngAddress, "My Empoyer");

            loanApp.Borrowers[0].Employer = emp;

            loanApp.Prequalify();

            Assert.AreEqual(loanApp.Status, Status.Declined);
        }

        [Test]
        public void A_Loan_Applications_Status_Will_Change_To_OfferGiven_After_Prequalification()
        {
            LoanApplication loanApp = CreateAValidLoanApplicationAwaitingPrequalification();

            loanApp.Prequalify();

            Assert.AreEqual(loanApp.Status, Status.OfferGiven);
        }

        #endregion

        #region Printing Offer Letter Tests

        [Test]
        public void An_Offer_That_Is_First_Generated_Must_Match_The_Application_Amount()
        {
            LoanApplication loanApp = CreateAValidLoanApplicationAwaitingPrequalification();

            loanApp.Prequalify();

            Offer offer = loanApp.GetOfferInPrincipal();

            Assert.AreEqual(offer.LoanAmount, loanApp.LoanAmount);            
        }

        [Test]
        [ExpectedException(typeof(AnOfferInPrincipalHasNotBeenGenerated))]
        public void An_Exception_Will_Be_Thrown_If_An_Offer_Attempted_To_Be_Retrieved_Before_Prequalification()
        {
            LoanApplication loanApp = CreateAValidLoanApplicationAwaitingPrequalification();

            Assert.AreEqual(loanApp.GetOfferInPrincipal().LoanAmount, loanApp.LoanAmount);
        }


        [Test]
        [ExpectedException(typeof(Exception))]
        public void An_Exception_Will_Be_Thrown_If_An_Offer_Is_Attempted_To_Be_Retrieved_If_It_Is_Expired()
        {
            LoanApplication loanApp = CreateAValidLoanApplicationAwaitingPrequalification();

            loanApp.Prequalify();

            // Set by reflection

            loanApp.GetOfferInPrincipal();
        }

        
        #endregion

        #region  Loan Factory Methods

        public LoanApplication CreateAValidLoanApplicationAwaitingPrequalification()
        {

            LoanApplication loanApp = new LoanApplication();

            Product product = new Product();
            product.InterestRate = 1.25f;
            product.Name = "Tracker A";
            product.MaximumLTV = 95;
            product.MaximumLoan = 200000;
            product.MaximumLoanTerm = 35;

            IAddress address = new StubAddress();
            IBankAccount bankAccount = new StubBankAccount();

            loanApp.Product = product;
            loanApp.PropertyAddress = address;
            loanApp.LoanAmount = 80000;
            loanApp.PropertyValue = 100000;
            loanApp.LoanTerm = 30;
            loanApp.Deposit = 20000;

            Borrower borrower = new Borrower();

            Employer employer = new Employer(3000, address, "IBM");
            CreditScore creditScore = new CreditScore("Experian", 800);

            borrower.Employer = employer;
            borrower.CreditScore = creditScore;
            borrower.BankAccount = bankAccount;
            borrower.ContactAddress = address;
            borrower.Age = 21;
            borrower.FirstName = "Scott";
            borrower.LastName = "Millett";

            loanApp.Add(borrower);

            loanApp.Status = Status.AwaitingPrequalification;

            return loanApp;

        }
        #endregion
    }
}
