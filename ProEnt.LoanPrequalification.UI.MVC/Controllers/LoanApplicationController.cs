using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using ProEnt.LoanPrequalification.UI.MVC.LoanApplicationService;
using ProEnt.LoanPrequalification.UI.MVC.ProductService;
using System.Text.RegularExpressions;

namespace ProEnt.LoanPrequalification.UI.MVC.Controllers
{
    public class LoanApplicationController : Controller
    {
        private ILoanApplicationService _loanService;
        private IProductService _productService;

        public LoanApplicationController(ILoanApplicationService loanService, IProductService productService)
        {
            _loanService = loanService;
            _productService = productService;
        }

        //
        // GET: /LoanApplication/

        public ActionResult Index()
        {            
            LoanApplicationListResponse response = _loanService.GetAllLoanApplications();

            if (response.Success)
            {
                LoanApplicationSummaryView[] loanApplicationDTOS = response.LoanApplications;
                return View(loanApplicationDTOS);
            }
            else
            {
                ViewData["Error"] = response.Message;
                return View("Error");
            }            
        }

        //
        // GET: /LoanApplication/Details/5

        public ActionResult Details(string id)
        {            
            LoanApplicationGetByIdRequest loanApplicationGetByIdRequest = new LoanApplicationGetByIdRequest();

            loanApplicationGetByIdRequest.Id = id;

            LoanApplicationGetByIdResponse response = _loanService.GetLoanApplicationById(loanApplicationGetByIdRequest);

            if (response.Success == true)
            {
                return View(response.LoanApplication);
            }
            else
            {
                ViewData["Error"] = response.Message;
                return View("Error");
            }
            
        }

        //
        // GET: /LoanApplication/OfferLetter/5

        public ActionResult OfferLetter(string id)
        {            
            OfferLetterGetByIdRequest offerLetterGetByIdRequest = new OfferLetterGetByIdRequest();

            offerLetterGetByIdRequest.Id = id;

            OfferLetterGetByIdResponse response = _loanService.GetOfferLetterForLoanApplicationById(offerLetterGetByIdRequest);

            if (response.Success == true)
            {
                return View(response.OfferLetter);
            }
            else
            {
                ViewData["Error"] = response.Message;
                return View("Error");
            }

        }

        //
        // GET: /LoanApplication/Create

        public ActionResult Create()
        {           
            PopulateViewDataWithProductList();
            return View();

        }

        private void PopulateViewDataWithProductList()
        {
            ProductService.ProductListResponse response = _productService.GetAllProducts();

            if (response.Success)
            {
                ProductService.ProductView[] products = response.Products;

                ViewData["ProductList"] = new SelectList(products, "Id", "Name");                
            }
            else
            {
                ViewData["Error"] = response.Message;                
            }   
        }

        //
        // POST: /LoanApplication/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(LoanApplicationCreateView loanApp, FormCollection collection)
        {                               
                LoanApplicationService.LoanApplicationCreateRequest request = new LoanApplicationService.LoanApplicationCreateRequest();
                request.LoanApplicationView = loanApp;
                                           
                    LoanApplicationService.LoanApplicationCreateResponse response = _loanService.SubmitLoanApplication(request);

                    if (response.Success == true)
                    {
                        ViewData["LoanApplicationId"] = response.LoanApplicationId;
                        return View("CreateSuccessful");
                    }
                    else
                    {
                        PopulateViewDataWithProductList();

                        string[] errors = response.Message.Split('.');

                        foreach (string s in errors)
                        {
                            ModelState.AddModelError("", s);
                        }

                        return View(loanApp);
                    }
                                                                                      
                  
        }

                   
    }
}
