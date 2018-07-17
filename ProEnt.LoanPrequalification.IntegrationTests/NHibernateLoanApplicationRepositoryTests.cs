using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using NUnit.Framework;
using ProEnt.LoanPrequalification.Model;
using ProEnt.LoanPrequalification.Model.LoanApplications;
using ProEnt.LoanPrequalification.Model.Products;
using ProEnt.LoanPrequalification.Model.Borrowers;
using ProEnt.LoanPrequalification.Repositories.NHibernate;

namespace ProEnt.LoanPrequalification.IntegrationTests
{
    [TestFixture]
    public class NHibernateLoanApplicationRepositoryTests
    {
        [SetUp]
        public void SetUp()
        {
             // Clear the database            
            string connectionString = ConfigurationManager.ConnectionStrings["LoanDBConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))   
             {
                 using (SqlCommand cmd = new SqlCommand("sClearDB", connection))
                 {
                     cmd.CommandType = CommandType.StoredProcedure;
                     connection.Open();
                     cmd.ExecuteNonQuery();                    
                 }                 
             }
        }

        [Test]
        public void Can_Add_LoanApplication_To_Repository()
        {
            // Add Product
            Product product = CreateProduct();           
            // Add Borrower
            Borrower borrower = CreateBorrower();

            // Create a Loan
            LoanApplication loanApplication = new LoanApplication();            
            loanApplication.Product = product;
            loanApplication.Add(borrower);
            //borrower.LoanApplication = loanApplication;

            // Add Property Address
            Address address = new Address("Street", "Town", "City", "postCode");
            loanApplication.PropertyAddress = address;

            // Add some Debts
            Debt debt = new Debt();
            debt.MonthlyPayment = 300;
            debt.Description = "A Debt";
            debt.CreditorName = "creditor";
            debt.BalanceOwed = 4000;
            loanApplication.Debts.Add(debt);
            debt.LoanApplication = loanApplication;

            // Add some Assets
            Asset asset = new Asset();
            asset.AccountNumber = "87687678";
            asset.Balance = 70000;
            asset.Description = "Desc..";
            loanApplication.Assets.Add(asset);
            asset.LoanApplication = loanApplication;

            LoanApplicationRepository loanApplicationRepository = new LoanApplicationRepository();

            loanApplicationRepository.Add(loanApplication);

            Assert.AreEqual(1, loanApplicationRepository.FindAll().Count);

        }

        #region helper methods

        private Product CreateProduct()
        {
            ProductRepository productRepository = new ProductRepository();

            Product productToAdd = new Product
            {
                InterestRate = 1.25f,
                MaximumLoan = 10000,
                MaximumLoanTerm = 35,
                MaximumLTV = 98f,
                Name = "Test Product"
            };

            productRepository.Add(productToAdd);

            return productToAdd;
           
        }
        
        private Borrower CreateBorrower()
        {
            BorrowerRepository borrowerRepository = new BorrowerRepository();

            BankAccount bankAccount = new BankAccount("86578678", "Scott A Millett", "90-90-90", "Lloydstsb");
            Address contactAddress = new Address("My Street", "My Town", "My City", "My PostCode");
            Employer employer = new Employer(1500f, contactAddress, "Company XYZ");
            CreditScore creditScore = new CreditScore("Credit Agency", 800);
            Borrower borrower = new Borrower();

            borrower.BankAccount = bankAccount;
            borrower.ContactAddress = contactAddress;
            borrower.CreditScore = creditScore;
            borrower.Employer = employer;
            borrower.Age = 31;
            borrower.FirstName = "Scott";
            borrower.LastName = "Millett";

            borrowerRepository.Add(borrower);

            return borrower;
        }

        #endregion

    }
}
