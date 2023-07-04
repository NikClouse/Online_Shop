using OnlineShop.Db.Models;
using OnlineShopWebApp.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace OnlineShopWebApp.Models
{
	public class ProductViewModel
	{

		public Guid Id { get; set; }

		[Required(ErrorMessage = "Введите имя")]
		public string Name { get; set; }

		[Range(0, 1000000, ErrorMessage = "Цена должна быть в переделах от 0 до 1 000 000 руь.")]
		public decimal Cost { get; set; }

		[Required(ErrorMessage = "Введите описание")]
		public string Description { get; set; }

		public string[] ImagesPaths { get; set; }

		public string ImagePath => ImagesPaths.Length == 0 ? "/img/Products/honor.jfif" : ImagesPaths[0];
		public ProductCategory NameCategory { get; set; }
		public List<CategoryViewModel> Categories { get; set; }

	}
}
