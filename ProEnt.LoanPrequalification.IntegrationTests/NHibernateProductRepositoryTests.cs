using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using NUnit.Framework;
using ProEnt.LoanPrequalification.Model.LoanApplications;
using ProEnt.LoanPrequalification.Model.Products;
using ProEnt.LoanPrequalification.Repositories.NHibernate;

namespace ProEnt.LoanPrequalification.IntegrationTests
{
    [TestFixture]
    public class NHibernateProductRepositoryTests
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
        public void Can_Add_Product_To_Repository()
        {
            ProductRepository productRepository = new ProductRepository();

            productRepository.Add(new Product
                                      {
                                          InterestRate = 1.25f,
                                          MaximumLoan = 10000,
                                          MaximumLoanTerm = 35,
                                          MaximumLTV = 98f,
                                          Name = "Test Product"
                                      });


            Assert.AreEqual(1, productRepository.FindAll().Count);
        }

        [Test]
        public void Can_Find_A_Product_By_Id()
        {
            Guid productId;
            float interestRate = 1.25f;
            int maximumLoan = 10000;
            int maximumLoanTerm = 35;
            float maximumLTV = 98f;
            string name = "Test Product";

            ProductRepository productRepository = new ProductRepository();

            Product productToAdd = new Product
            {
                InterestRate = interestRate,
                MaximumLoan = maximumLoan,
                MaximumLoanTerm = maximumLoanTerm,
                MaximumLTV = maximumLTV,
                Name = name
            };

            productRepository.Add(productToAdd);
            productId = productToAdd.Id;

            productRepository = new ProductRepository();
            Product productToFind = productRepository.FindBy(productId);

            Assert.AreEqual(interestRate, productToFind.InterestRate);
            Assert.AreEqual(maximumLoan, productToFind.MaximumLoan);
            Assert.AreEqual(maximumLoanTerm, productToFind.MaximumLoanTerm);
            Assert.AreEqual(maximumLTV, productToFind.MaximumLTV);
            Assert.AreEqual(name, productToFind.Name);

                        
        }

        [Test]
        public void Can_Save_Changes_To_A_Product()
        {
            Guid productId;
            ProductRepository productRepository;
            string originalProductName = "Test Product";
            string amendedProductName = "Amended Test Product";

            productRepository = new ProductRepository();
            Product productToAdd = new Product
                {
                    InterestRate = 1.25f,
                    MaximumLoan = 10000,
                    MaximumLoanTerm = 35,
                    MaximumLTV = 98f,
                    Name = originalProductName
                };

            productRepository.Add(productToAdd);
            productId = productToAdd.Id;
            Assert.AreEqual(1, productRepository.FindAll().Count);

            productRepository = new ProductRepository();
            Product productToAmend = productRepository.FindBy(productId);
            Assert.AreEqual(originalProductName, productToAmend.Name);
            productToAmend.Name = amendedProductName;
            productRepository.Save(productToAmend);

            productRepository = new ProductRepository();
            Product productAmended = productRepository.FindBy(productId);
            Assert.AreEqual(amendedProductName, productAmended.Name);                        

        }
    }
}
