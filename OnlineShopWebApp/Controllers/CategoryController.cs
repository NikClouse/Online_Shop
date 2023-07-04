using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Helpers;

namespace OnlineShopWebApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryRepozitory categoryRepozitory;
        public CategoryController(CategoryRepozitory categoryRepozitory)
        {
            this.categoryRepozitory = categoryRepozitory;
        }

        public IActionResult Index()
        {
            var categories = categoryRepozitory.GetAll();

            var categoriesViewModels = categories.ToProductCategoryViewModels();

            return View(categoriesViewModels);

        }


    }
}
