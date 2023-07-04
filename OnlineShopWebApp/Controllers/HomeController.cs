using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Helpers;
using System.Linq;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {

        private readonly IProductRepozitory productRepozitory;
        private readonly CategoryRepozitory categoryRepozitory;
        private readonly DatabaseContext databaseContext;
        public HomeController(IProductRepozitory productRepozitory, CategoryRepozitory categoryRepozitory, DatabaseContext databaseContext)
        {
            this.productRepozitory = productRepozitory;
            this.categoryRepozitory = categoryRepozitory;
            this.databaseContext = databaseContext;
        }
        public IActionResult Index()
        {

            var products = productRepozitory.GetAll();


            return View(Mapping.ToProductViewModels(products));

        }




        public IActionResult Category()
        {
            var categories = categoryRepozitory.GetAll();

            var categoriesViewModels = categories.ToProductCategoryViewModels();

            return View(categoriesViewModels);
        }


        [HttpPost]
        public IActionResult CategoryProduct(int categoryId)
        {
            var products = databaseContext.ProductCategories.FirstOrDefault(x => x.Id == categoryId);//GetProductsByCategoryId(categoryId);
            return View(products);
        }



        [HttpPost]
        public IActionResult Search(string search)
        {

            var products = productRepozitory.GetAll();
            //  var product = products.FirstOrDefault(x => x.Name == search);
            products = products.Where(product => product.Name.ToLower()
            .StartsWith(search.ToLower()))
                .ToList();
            return View(Mapping.ToProductViewModels(products));//работа с Viev
        }


        public IActionResult Contact()
        {
            return View();
        }
    }
}
