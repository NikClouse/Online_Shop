using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Areas.Admin.Models
{
    public class CategoryRightViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public List<CategoryViewModel> Categories { get; set; }


    }
}
