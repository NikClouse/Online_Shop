using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Db
{
    public class ProductDbRepozitory : IProductRepozitory
    {
        private readonly DatabaseContext databaseContext;


        public ProductDbRepozitory(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;

        }

        private readonly IProductRepozitory product;//


        //private static List<Product> products = new List<Product>()
        // {
        //  new Product("Iphon SE",100,"Iphpon SE3","/img/iphons7.jfif"),
        //  new Product("Huawei",200,"Huawei Psmart 2019","/img/huaweip.jfif"),
        //  new Product("Samsung A11",300,"Samsung Galaxy s20","/img/samsungs10.jfif"),
        //  new Product("Sony",400,"Sony Explore","/img/sony.jfif"),
        //  new Product("Huawei P smart ",500,"Huawei Nova 8", "/img/huaweis20.jfif"),
        //  new Product("Samsung S20",450,"Samsung A11", "/img/samsungs10.jfif"),
        //  new Product("Honor Lite10",350,"Honor Lite 10", "/img/honor.jfif"),
        //  new Product("Alcatel",220,"Alcatel f12", "/img/alcatel.jfif"),
        //  new Product("Iphon S7",400,"Iphon xr", "/img/iphons6.jfif"),
        // };

        public void Add(Product product)
        {

            databaseContext.Products.Add(product);
            databaseContext.SaveChanges();
        }

        public List<Product> GetAll()
        {
            return databaseContext.Products.Include(x => x.Images).ToList();
        }

        public Product TryGetById(Guid id)
        {
            return databaseContext.Products.Include(x => x.Images).FirstOrDefault(product => product.Id == id);
        }



        public void Update(Product product)
        {

            var existingProduct = databaseContext.Products.Include(x => x.Images).FirstOrDefault(x => x.Id == product.Id);


            if (existingProduct == null)
            {
                return;
            }



            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Cost = product.Cost;

            foreach (var images in product.Images)
            {
                images.ProductId = product.Id;
                databaseContext.Add(images);
            }
            //databaseContext.Products.Update(product);

            databaseContext.SaveChanges();

        }

        public void Remove(Guid productId)
        {
            var products = databaseContext.Products.FirstOrDefault(x => x.Id == productId);
            databaseContext.Products.Remove(products);

            databaseContext.SaveChanges();


        }

        public object TryGetByCategoryId(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}