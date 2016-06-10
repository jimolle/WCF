using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CompanyWebUI.ServiceReference;


// Skriv en ny service för att söka efter en produkt
// Felhantering på serversidan
//OK// Felhantering på klientsidan
//OK// "Produktportalen ska stödja REST till klienterna"


namespace CompanyWebUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string info;
            string info2;

            try
            {
                using (var proxy = new ProductServiceClient())
                {
                    info = proxy.Endpoint.Binding.Name;
                    info2 = proxy.Endpoint.Address.Uri.ToString();
                }

                ViewBag.Info = info;
                ViewBag.Info2 = info2;

                using (var client = new HttpClient())
                {
                    var test = Url.RouteUrl(
                        "DefaultApi",
                        new { httproute = "", controller = "Data", action = "GetAllProducts" },
                        Request.Url.Scheme
                    );
                    var model = client
                                .GetAsync(test)
                                .Result
                                .Content.ReadAsAsync<Product[]>().Result;

                    return View(model);
                }
            }
            catch (Exception)
            {
                
                //...
                return View(new List<Product>()
                {
                    new Product() {Name = "Servicen ligger nere, och vilken väg detta meddelande tog!"}
                });
            }


        }

        public async Task<ActionResult> About()
        {
            Product[] products;

            using (var proxy = new ProductServiceClient())
            {
                products = await proxy.GetByCategoryAsync("Verktyg och maskiner");
            }

            return View(products);
        }


        // AJAX TESTPAGE
        public ActionResult Search()
        {
            return View();
        }

        // AJAX ACTIONLINK
        public ActionResult ShowByCategory(string cat)
        {
            using (var client = new HttpClient())
            {
                var test = Url.RouteUrl(
                    "DefaultApi",
                    new { httproute = "", controller = "Data", action = "GetByCategory", search = cat },
                    Request.Url.Scheme
                );
                var model = client
                            .GetAsync(test)
                            .Result
                            .Content.ReadAsAsync<Product[]>().Result;


                return PartialView("_DailyDeal", model);
            }

        }

        //AJAX FORM
        public ActionResult ProductSearch(string q)
        {
            var products = GetProducts(q);
            return PartialView("_ProductSearch", products);
        }

        //AJAX AUTOCOMPLETE
        public ActionResult QuickSearch(string term)
        {
            var products = GetProducts(term).Select(a => new { value = a.Name });
            return Json(products, JsonRequestBehavior.AllowGet);
        }



        private static IEnumerable<Product> GetProducts(string searchString)
        {
            IEnumerable<Product> products;

            using (var proxy = new ProductServiceClient())
            {
                products = proxy.GetAllProducts().Where(n => n.Name.ToUpper().Contains(searchString.ToUpper()));
            }
            return products;
        }

    }
}