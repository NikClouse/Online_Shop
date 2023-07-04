using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Helpers;
using System;

namespace OnlineShopWebApp.Controllers
{
	public class ProductController : Controller
	{
		private readonly IProductRepozitory productRepozitory;
		public ProductController(IProductRepozitory productRepozitory)
		{
			this.productRepozitory = productRepozitory;
		}
		public IActionResult Index(Guid id)
		{
			var product = productRepozitory.TryGetById(id);
			var products = Mapping.ToProductViewModel(product);

			return View(products);
		}
	}


}
