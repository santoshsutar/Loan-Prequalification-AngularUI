using System;
using System.Collections.Generic;
using System.Text;

namespace ProEnt.LoanPrequalification.Model.Products
{
    public class ProductService
   {
        private IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }


        public Product FindBy(Guid productId)
        {
            Product borrower = productRepository.FindBy(productId);
            if (borrower == null)
                throw new Exception(String.Format("Cannot find a product with the ID '{0}'.", productId.ToString()));

            return borrower;
        }

        public void Save(Product product)
        {
            if (product.GetBrokenRules().Count > 0)
            {
                throw new ArgumentException(
                    String.Format("This product is invalid and cannot be saved in its present state. '{0}'", GetBrokenRulesToStringFor(product.GetBrokenRules())));
            }
            productRepository.Save(product);
        }

        public List<Product> FindAll()
        {
            return productRepository.FindAll();
        }

        private string GetBrokenRulesToStringFor(List<BrokenBusinessRule> brokenRules)
        {
            StringBuilder sbBrokenRules = new StringBuilder();

            foreach (BrokenBusinessRule br in brokenRules)
            {
                sbBrokenRules.Append(br.Rule);
            }

            return sbBrokenRules.ToString();
        }
    }
}
