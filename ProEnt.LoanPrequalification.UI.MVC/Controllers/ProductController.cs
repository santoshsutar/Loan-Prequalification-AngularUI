using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using ProEnt.LoanPrequalification.UI.MVC.ProductService;
using WroxProf.LoanApproval.UI.MVC;

namespace ProEnt.LoanPrequalification.UI.MVC.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        //
        // GET: /Product/

        public ActionResult Index()
        {
            ProductService.ProductListResponse response = _productService.GetAllProducts();

            if (response.Success)
            {
                ProductService.ProductView[] products = response.Products;
                return View(products);
            }
            else
            {
                ViewData["Error"] = response.Message;
                return View("Error");
            }
        }

        //
        // GET: /Product/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Product/Create


        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(ProductView product, FormCollection collection)
        {
            ProductService.ProductCreateResponse response = CreateProductForAPI(product);

            if (response.Success == true)
            {
                return View("Details", response.Product);
            }
            else
            {
                string[] errors = response.Message.Split('.');

                foreach (string s in errors)
                {
                    ModelState.AddModelError("", s);
                }


                return View();
            }
        }

        public ProductService.ProductCreateResponse CreateProductForAPI(ProductView product)
        {
            ProductService.ProductCreateRequest request = new ProductService.ProductCreateRequest();

            request.Product = product;
            ProductService.ProductCreateResponse response = _productService.CreateProduct(request);
            return response;
        }

        //
        // GET: /Product/Details

        public ActionResult Details(string id)
        {
            ProductService.ProductGetRequest request = new ProductService.ProductGetRequest();
            request.ProductId = id;
            ProductService.ProductGetResponse response = _productService.GetProduct(request);

            if (response.Success)
            {
                ProductService.ProductView product = response.Product;
                return View(product);
            }
            else
            {
                ViewData["Error"] = response.Message;
                return View("Error");
            }

        }

    }
}
