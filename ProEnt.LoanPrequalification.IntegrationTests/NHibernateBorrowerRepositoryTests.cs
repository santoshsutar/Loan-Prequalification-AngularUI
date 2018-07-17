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
    public class NHibernateBorrowerRepositoryTests
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
        public void Can_Add_Borrower_To_Repository()
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
            
            Assert.AreEqual(1, borrowerRepository.FindAll().Count);
        }
    }
}
