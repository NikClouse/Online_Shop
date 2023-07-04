using System.Collections.Generic;

namespace OnlineShop.Db.Models
{
	public class ProductCategory
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public virtual List<Product> Products { get; set; }

		public ProductCategory(int id, string categoryName)
		{
			Id = id;
			Name = categoryName;
		}
		public ProductCategory()
		{
			Products = new List<Product>();
		}
	}
}
