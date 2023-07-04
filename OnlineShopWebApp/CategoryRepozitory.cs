using OnlineShop.Db;
using OnlineShop.Db.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp
{
	public class CategoryRepozitory
	{
		private readonly DatabaseContext databaseContext;


		public CategoryRepozitory(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;


		}

		public List<ProductCategory> GetAll()
		{
			return databaseContext.ProductCategories.ToList();
		}

		public void Add(ProductCategory category)
		{
			databaseContext.ProductCategories.Add(category);
			databaseContext.SaveChanges();
		}


		public ProductCategory GetByName(string categoryName)
		{

			return databaseContext.ProductCategories.FirstOrDefault(x => x.Name == categoryName);

		}



		public void RemoveCategory(ProductCategory category)
		{
			databaseContext.ProductCategories.Remove(category);
			databaseContext.SaveChanges();
		}


		public void Remove(int categoryId)
		{

			var categories = databaseContext.ProductCategories.FirstOrDefault(x => x.Id == categoryId);
			databaseContext.ProductCategories.Remove(categories);
			databaseContext.SaveChanges();

		}


		public void Update(ProductCategory product)
		{
			var existingProduct = databaseContext.ProductCategories.FirstOrDefault(x => x.Id == product.Id);

			if (existingProduct == null)
			{
				return;
			}


			existingProduct.Id = product.Id;
			existingProduct.Name = product.Name;

			databaseContext.SaveChanges();

		}


		public ProductCategory TryGetById(int id)
		{
			return databaseContext.ProductCategories.FirstOrDefault(x => x.Id == id);
		}

		public void Remove(ProductCategory category)
		{
			var categories = databaseContext.ProductCategories.FirstOrDefault(x => x.Id == category.Id);
			databaseContext.Remove(category);
			databaseContext.SaveChanges();
		}
	}
}
