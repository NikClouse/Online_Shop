using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;


namespace OnlineShop.Db
{
    public class Product
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Cost { get; set; }

        public string Description { get; set; }

        public List<Image> Images { get; set; }

        public List<CartItem> CartItems { get; set; }
        public List<FavoriteProduct> FavoriteProducts { get; set; }
        public virtual ProductCategory ProductCategories { get; set; }

        public Product(Guid id, string name, decimal cost, string description)
        {
            Id = id;
            Name = name;
            Cost = cost;
            Description = description;



        }

        public Product()
        {
            CartItems = new List<CartItem>();
            FavoriteProducts = new List<FavoriteProduct>();
            Images = new List<Image>();
            ProductCategories = new ProductCategory();
            //ProductCategoryId = productCategoryId;

        }


    }

}