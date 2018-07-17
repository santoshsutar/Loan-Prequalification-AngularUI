using System;using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProEnt.LoanPrequalification.Model;
using ProEnt.LoanPrequalification.Model.Borrowers; 
using ProEnt.LoanPrequalification.Model.Products;
using ProEnt.LoanPrequalification.Model.LoanApplications;

namespace ProEnt.LoanPrequalification.Service.Views
{
    public class Mapper
    {
        #region Debt Mapping

        public static DebtView BuildDebtViewFrom(Debt debt)
        {
            DebtView debtView = new DebtView
            {
                BalanceOwed = debt.BalanceOwed,
                CreditorName = debt.CreditorName,
                Description = debt.Description,
                MonthlyPayment = debt.MonthlyPayment 
            };

            return debtView;
        }

        #endregion

        #region Asset Mapping

        public static AssetView BuildAssetViewFrom(Asset asset)
        {
            AssetView assetView = new AssetView
            {
                 AccountNumber = asset.AccountNumber,
                 Balance = asset.Balance,
                 Description = asset.Description  
            };

            return assetView;
        }

        #endregion

        #region Product Mapping

        public static Product BuildEntityFrom(ProductView productView)
        {
            Product productEntity = new Product
            {                
                Name = productView.Name,
                InterestRate = productView.InterestRate,
                MaximumLoan = productView.MaximumLoan,
                MaximumLoanTerm = productView.MaximumLoanTerm,
                MaximumLTV = productView.MaximumLTV   
            };

            if (!String.IsNullOrEmpty(productView.Id))
            {
                productEntity.Id = new Guid(productView.Id);
            }            

            return productEntity;
        }

        public static ProductView BuildViewFrom(Product product)
        {
            ProductView productView = new ProductView
            {
                Id = product.Id.ToString(),
                Name = product.Name,
                InterestRate = product.InterestRate,
                MaximumLoan = product.MaximumLoan,
                MaximumLoanTerm = product.MaximumLoanTerm,
                MaximumLTV = product.MaximumLTV                  
            };

            return productView;
        }

        #endregion

        #region Borrower Mapping


        public static BorrowerView BuildBorrowerViewFrom(Borrower borrower)
        {
            BorrowerView borrowerView = new BorrowerView
            {
                 FirstName = borrower.FirstName,
                 LastName = borrower.LastName,
                 Age = borrower.Age                
            };

            return borrowerView;
        }

        #endregion

        #region Loan Application Mapping

        public static LoanApplicationDetailView CreateLoanApplicationDetailViewFrom(LoanApplication loanApp)
        {
            LoanApplicationDetailView loanApplicationDetailView = new LoanApplicationDetailView
            {
                Id = loanApp.Id.ToString(),
                Deposit = loanApp.Deposit,
                HasOffer = loanApp.HasOffer(),
                LoanAmount = loanApp.LoanAmount,
                LoanTerm = loanApp.LoanTerm,
                PropertyValue = loanApp.PropertyValue,
                Status = loanApp.Status.ToString(), 
                ProductName = loanApp.Product.Name,

                PropertyStreet = loanApp.PropertyAddress.Street,  
                PropertyTown = loanApp.PropertyAddress.Town,
                PropertyCity = loanApp.PropertyAddress.City,
                PropertyPostCode = loanApp.PropertyAddress.PostCode
            };

            foreach (Borrower borrower in loanApp.Borrowers)
            {
                loanApplicationDetailView.Borrowers.Add(BuildBorrowerViewFrom(borrower));
            }

            foreach (Asset asset in loanApp.Assets)
            {
                loanApplicationDetailView.Assets.Add(BuildAssetViewFrom(asset));
            }

            foreach (Debt debt in loanApp.Debts)
            {
                loanApplicationDetailView.Debts.Add(BuildDebtViewFrom(debt));
            }

            return loanApplicationDetailView;
        }
                    

        public static OfferLetterView CreateOfferLetterViewFrom(LoanApplication loanApplication)
        {
            OfferLetterView offerLetterView = new OfferLetterView();
            Offer loanOffer = loanApplication.GetOfferInPrincipal();

            offerLetterView.ExpirationDate = loanOffer.ExpirationDate;
            offerLetterView.InterestRate = loanOffer.InterestRate;
            offerLetterView.LoanAmount = loanOffer.LoanAmount;
            offerLetterView.LoanTerm = loanOffer.LoanTerm;

            offerLetterView.LoanApplicationId = loanApplication.Id.ToString();
            offerLetterView.RecipientName = String.Format("{0} {1}", loanApplication.Borrowers[0].FirstName, loanApplication.Borrowers[0].LastName);
            offerLetterView.RecipientStreet = loanApplication.Borrowers[0].ContactAddress.Street;
            offerLetterView.RecipientTown = loanApplication.Borrowers[0].ContactAddress.Town;
            offerLetterView.RecipientCity = loanApplication.Borrowers[0].ContactAddress.City;
            offerLetterView.RecipientPostCode = loanApplication.Borrowers[0].ContactAddress.PostCode;


            return offerLetterView;

        }

        public static LoanApplication CreateLoanApplicationFrom(LoanApplicationCreateView LoanApplicationView)
        {
            LoanApplication loanApplication = new LoanApplication();

            loanApplication.LoanAmount = LoanApplicationView.LoanAmount;
            loanApplication.LoanTerm = LoanApplicationView.LoanTerm;
            loanApplication.Deposit = LoanApplicationView.Deposit;
            loanApplication.PropertyValue = LoanApplicationView.PropertyValue;

            Address loanPropertyAddress = new Address(LoanApplicationView.PropertyStreet, LoanApplicationView.PropertyTown, LoanApplicationView.PropertyCity, LoanApplicationView.PropertyPostCode);
            loanApplication.PropertyAddress = loanPropertyAddress;

            Borrower borrower = new Borrower();
            borrower.FirstName = LoanApplicationView.Borrower1.FirstName;
            borrower.LastName = LoanApplicationView.Borrower1.LastName;
            borrower.Age = LoanApplicationView.Borrower1.Age;
            loanApplication.Add(borrower);

            Employer borrowerEmployer;
            Address borrowerEmployerAddress = new Address(LoanApplicationView.Borrower1.EmployerStreet, LoanApplicationView.Borrower1.EmployerTown, LoanApplicationView.Borrower1.EmployerCity, LoanApplicationView.Borrower1.EmployerPostCode);
            borrowerEmployer = new Employer(LoanApplicationView.Borrower1.MonthlyIncome, borrowerEmployerAddress, LoanApplicationView.Borrower1.EmployerName);
            borrower.Employer = borrowerEmployer;

            Address borrowerContactAddress = new Address(LoanApplicationView.Borrower1.Street, LoanApplicationView.Borrower1.Town, LoanApplicationView.Borrower1.City, LoanApplicationView.Borrower1.PostCode);
            borrower.ContactAddress = borrowerContactAddress;

            BankAccount borrowerBankAccount = new BankAccount(LoanApplicationView.Borrower1.BankAccountNumber, LoanApplicationView.Borrower1.BankAccountname, LoanApplicationView.Borrower1.BankSortCode, LoanApplicationView.Borrower1.BankName);
            borrower.BankAccount = borrowerBankAccount;

            CreditScore borrowerCreditScore = new CreditScore(LoanApplicationView.Borrower1.CreditAgency, LoanApplicationView.Borrower1.CreditScore);
            borrower.CreditScore = borrowerCreditScore;

            if (LoanApplicationView.HasSecondBorrower)
            {
                Borrower borrower2 = new Borrower();
                borrower2.FirstName = LoanApplicationView.Borrower2.FirstName;
                borrower2.LastName = LoanApplicationView.Borrower2.LastName;
                borrower2.Age = LoanApplicationView.Borrower2.Age;
                loanApplication.Add(borrower2);

                Employer borrowerEmployer2;
                Address borrowerEmployerAddress2 = new Address(LoanApplicationView.Borrower2.EmployerStreet, LoanApplicationView.Borrower2.EmployerTown, LoanApplicationView.Borrower2.EmployerCity, LoanApplicationView.Borrower2.EmployerPostCode);
                borrowerEmployer2 = new Employer(LoanApplicationView.Borrower2.MonthlyIncome, borrowerEmployerAddress2, LoanApplicationView.Borrower2.EmployerName);
                borrower2.Employer = borrowerEmployer2;

                Address borrowerContactAddress2 = new Address(LoanApplicationView.Borrower2.Street, LoanApplicationView.Borrower2.Town, LoanApplicationView.Borrower2.City, LoanApplicationView.Borrower2.PostCode);
                borrower2.ContactAddress = borrowerContactAddress2;

                BankAccount borrowerBankAccount2 = new BankAccount(LoanApplicationView.Borrower2.BankAccountNumber, LoanApplicationView.Borrower2.BankAccountname, LoanApplicationView.Borrower2.BankSortCode, LoanApplicationView.Borrower2.BankName);
                borrower2.BankAccount = borrowerBankAccount2;

                CreditScore borrowerCreditScore2 = new CreditScore(LoanApplicationView.Borrower2.CreditAgency, LoanApplicationView.Borrower2.CreditScore);
                borrower2.CreditScore = borrowerCreditScore2;
            }

            Asset asset;

            if (LoanApplicationView.Asset1.Balance != 0 || (String.IsNullOrEmpty(LoanApplicationView.Asset1.AccountNumber ) == false))            
            {    
                asset = new Asset { AccountNumber = LoanApplicationView.Asset1.AccountNumber, Balance = LoanApplicationView.Asset1.Balance, Description = LoanApplicationView.Asset1.Description };
                asset.LoanApplication = loanApplication;
                loanApplication.Assets.Add(asset);
            }

            if (LoanApplicationView.Asset2.Balance != 0 || (String.IsNullOrEmpty(LoanApplicationView.Asset2.AccountNumber ) == false))
            {
                asset = new Asset { AccountNumber = LoanApplicationView.Asset2.AccountNumber, Balance = LoanApplicationView.Asset2.Balance, Description = LoanApplicationView.Asset2.Description };
                asset.LoanApplication = loanApplication;
                loanApplication.Assets.Add(asset);
            }

            if (LoanApplicationView.Asset3.Balance != 0 || (String.IsNullOrEmpty(LoanApplicationView.Asset3.AccountNumber ) == false))
            {
                asset = new Asset { AccountNumber = LoanApplicationView.Asset3.AccountNumber, Balance = LoanApplicationView.Asset3.Balance, Description = LoanApplicationView.Asset3.Description };
                asset.LoanApplication = loanApplication;
                loanApplication.Assets.Add(asset);                
            }

            Debt debt;

            if (LoanApplicationView.Debt1.BalanceOwed != 0 || (String.IsNullOrEmpty(LoanApplicationView.Debt1.CreditorName) == false))
            {
                debt = new Debt { BalanceOwed = LoanApplicationView.Debt1.BalanceOwed, CreditorName = LoanApplicationView.Debt1.CreditorName, Description = LoanApplicationView.Debt1.Description };
                debt.LoanApplication = loanApplication;
                loanApplication.Debts.Add(debt); 
            }

            if (LoanApplicationView.Debt2.BalanceOwed != 0 || (String.IsNullOrEmpty(LoanApplicationView.Debt2.CreditorName) == false))
            {
                debt = new Debt { BalanceOwed = LoanApplicationView.Debt2.BalanceOwed, CreditorName = LoanApplicationView.Debt2.CreditorName, Description = LoanApplicationView.Debt2.Description };
                debt.LoanApplication = loanApplication;
                loanApplication.Debts.Add(debt);
            }

            if (LoanApplicationView.Debt3.BalanceOwed != 0 || (String.IsNullOrEmpty(LoanApplicationView.Debt3.CreditorName) == false))
            {
                debt = new Debt { BalanceOwed = LoanApplicationView.Debt3.BalanceOwed, CreditorName = LoanApplicationView.Debt3.CreditorName, Description = LoanApplicationView.Debt3.Description };
                debt.LoanApplication = loanApplication;
                loanApplication.Debts.Add(debt);
            }
            
            
            return loanApplication;
        }

        public static LoanApplicationSummaryView BuildLoanApplicationSummaryViewFrom(LoanApplication loanApp)
        {
            LoanApplicationSummaryView loanAppSummaryView = new LoanApplicationSummaryView
            {
                Id = loanApp.Id.ToString(),                
                HasOffer = loanApp.HasOffer(),
                LoanAmount = loanApp.LoanAmount,                
                Status = loanApp.Status.ToString()
            };

            return loanAppSummaryView;
        }

        public static LoanApplication BuildEntityFrom(LoanApplicationCreateView loanApplicationView)
        {
            LoanApplication ploanAppEntity = new LoanApplication
            {
                Id = new Guid(loanApplicationView.Id),
                Deposit = loanApplicationView.Deposit,
                LoanAmount = loanApplicationView.LoanAmount,
                LoanTerm = loanApplicationView.LoanTerm,
                PropertyValue = loanApplicationView.PropertyValue
            };

            return ploanAppEntity;
        
        }

        #endregion        

    }
}
