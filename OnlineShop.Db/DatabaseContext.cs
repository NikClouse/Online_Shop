using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;

namespace OnlineShop.Db
{
	public class DatabaseContext : DbContext
	{
		public DbSet<Product> Products { get; set; }
		public DbSet<ProductCategory> ProductCategories { get; set; }

		public DbSet<Cart> Carts { get; set; }

		public DbSet<CartItem> CartItems { get; set; }

		public DbSet<FavoriteProduct> FavoriteProducts { get; set; }

		public DbSet<Order> Orders { get; set; }
		public DbSet<Order> Images { get; set; }

		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
		{
			Database.Migrate();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Image>().HasOne(x => x.Product).WithMany(x => x.Images).HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.Cascade);


			var product1Id = Guid.Parse("92bced76-82ba-4f44-af74-70eb7b31a6f9");
			var product2Id = Guid.Parse("ba7aec10-4500-49ad-8ee6-ddbe95371796");

			var image1 = new Image
			{
				Id = Guid.Parse("d3630000-5d0f-0015-2872-08da3058ad5a"),
				Url = "/img/product/honor.jfif",
				ProductId = product1Id
			};

			var image2 = new Image
			{
				Id = Guid.Parse("68bfe1d6-a659-4407-aa2a-d38b10af42b1"),
				Url = "/img/product/Huawei19.jfif",
				ProductId = product2Id
			};

			modelBuilder.Entity<Image>().HasData(image1, image2);
			modelBuilder.Entity<Product>().HasData(new List<Product>()
			{
				new Product(product1Id,"Honor",15000,"Honor s10"),
				new Product(product2Id,"Huawei",20000,"Huawei nova 9"),
			});


		}


	}
}