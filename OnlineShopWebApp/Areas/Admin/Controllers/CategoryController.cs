using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
	[Area(Constans.AdminRoleName)]
	[Authorize(Roles = Constans.AdminRoleName)]
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




		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(CategoryViewModel category)
		{
			ProductCategory newCategory = new ProductCategory
			{
				Name = category.CategoryName,
				Products = new List<Product>()
			};

			categoryRepozitory.Add(newCategory);

			return RedirectToAction("Index");
		}

		public IActionResult Remove(int categoryId)
		{
			categoryRepozitory.Remove(categoryId);
			return RedirectToAction(nameof(Index));
		}

		[HttpPost]
		public IActionResult Remove(CategoryViewModel category)
		{
			if (!ModelState.IsValid)
			{
				return View(category);
			}

			var categoryDb = new ProductCategory
			{
				Name = category.CategoryName,
				Id = category.Id,

			};
			categoryRepozitory.Update(categoryDb);
			return RedirectToAction(nameof(Index));
		}





	}



}



