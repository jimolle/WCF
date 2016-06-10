using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CompanyWebUI.ServiceReference;

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
                        new { httproute = "", controller = "Data" },
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
                
                throw;
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


        // AJAX TESTPAGE HOME/CONTACT
        public ActionResult Contact()
        {
            return View();
        }

        // AJAX ACTIONLINK
        public ActionResult DailyDeal()
        {
            var product = GetDailyDeal();

            return PartialView("_DailyDeal", product);
        }
        private Product GetDailyDeal()
        {
            Product product;

            using (var proxy = new ProductServiceClient())
            {
                product = proxy.GetAllProducts().OrderBy(n => Guid.NewGuid()).First();
            }

            product.Price *= 666;
            //throw new UnauthorizedAccessException();
            return product;
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