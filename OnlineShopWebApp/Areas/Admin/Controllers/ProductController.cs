using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Areas.Admin.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using System;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
	[Area(Constans.AdminRoleName)]
	[Authorize(Roles = Constans.AdminRoleName)]
	public class ProductController : Controller
	{
		private readonly IProductRepozitory productRepozitory;
		private readonly ImagesProvider imagesProvider;
		private readonly CategoryRepozitory categoryRepozitory;
		private readonly DatabaseContext databaseContext;


		public ProductController(IProductRepozitory productRepozitory, ImagesProvider imagesProvider, CategoryRepozitory categoryRepozitory, DatabaseContext databaseContext)
		{
			this.productRepozitory = productRepozitory;
			this.imagesProvider = imagesProvider;
			this.categoryRepozitory = categoryRepozitory;
			this.databaseContext = databaseContext;
		}

		public IActionResult Index()
		{
			var products = productRepozitory.GetAll();
			return View(Mapping.ToProductViewModels(products));
		}

		public IActionResult Add()
		{
			var categories = categoryRepozitory.GetAll();
			var model = new AddProductViewModel()
			{
				Categories = categories.ToProductCategoryViewModels()
			};
			return View(model);
		}


		[HttpPost]
		public IActionResult Add(AddProductViewModel product)
		{
			if (!ModelState.IsValid)
			{
				return View(product);
			}

			var imagePath = imagesProvider.SafeFiles(product.UploadedFiles, ImageFolders.Products);
			// получить категорию по его названию с бд
			var category = categoryRepozitory.GetByName(product.SelectedCategoryName);
			productRepozitory.Add(product.ToProduct(imagePath, category)); // передать полученную категорию с бд
			return RedirectToAction(nameof(Index));
		}

		public IActionResult Edit(Guid productId)
		{
			var product = productRepozitory.TryGetById(productId);
			return View(product.ToEditProductViewModel());
		}

		[HttpPost]
		public IActionResult Edit(EditProductViewModel product)
		{
			if (!ModelState.IsValid)
			{

				return View(product);
			}
			var addImagePaths = imagesProvider.SafeFiles(product.UploadedFiles, ImageFolders.Products);
			product.ImagesPaths.AddRange(addImagePaths);
			productRepozitory.Update(product.ToProduct());
			return RedirectToAction(nameof(Index));
		}

		public IActionResult Remove(Guid productId)
		{
			productRepozitory.Remove(productId);
			return RedirectToAction(nameof(Index));
		}

		[HttpPost]
		public IActionResult Remove(EditProductViewModel product)
		{
			if (!ModelState.IsValid)
			{
				return View(product);
			}

			var productDb = new Product
			{
				Name = product.Name,
				Cost = product.Cost,
				Description = product.Description,
				//Images =
			};
			productRepozitory.Update(productDb);
			return RedirectToAction(nameof(Index));
		}



		//public ActionResult CategoryRight()
		//{

		//    var productCategories = categoryRepozitory.GetAll();


		//    List<CategoryRightViewModel> categoriesVM = new List<CategoryRightViewModel>();

		//    // Маппим список категорий в список моделей представления
		//    foreach (var category in productCategories)
		//    {
		//        categoriesVM.Add(new CategoryRightViewModel
		//        {
		//            Id = category.Id,
		//            CategoryName = category.Name

		//        });
		//    }

		//    return View(categoriesVM);
		//}



		//[HttpPost]
		//public IActionResult CategoryRight(Guid categoryId, CategoryRightViewModel categoryRightViewModel)
		//{
		//    var products = databaseContext.Products.Where(p => p.Id == categoryId).ToList();

		//    var category = new ProductCategory
		//    {
		//        Id = categoryRightViewModel.Id,
		//        Name = categoryRightViewModel.CategoryName,
		//        Products = products
		//    };
		//    categoryRepozitory.Save(category);

		//    return RedirectToAction(nameof(Add));
		//}

	}

}
