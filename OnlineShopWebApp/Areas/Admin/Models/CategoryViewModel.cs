using OnlineShop.Db;
using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public Product Products { get; set; }
        public List<CategoryViewModel> Categories { get; set; }


    }
}
