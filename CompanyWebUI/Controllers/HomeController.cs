using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
            List<Product> products;
            string info;
            string info2;

            try
            {
                using (var proxy = new ProductServiceClient())
                {
                    products = proxy.GetAllProducts().ToList();

                    info = proxy.Endpoint.Binding.Name;
                    info2 = proxy.Endpoint.Address.Uri.ToString();
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);

                // TODO kastar igen under debug...
                throw;
            }

            ViewBag.Info = info;
            ViewBag.Info2 = info2;

            return View(products);
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