using Microsoft.AspNetCore.Http;
using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Areas.Admin.Models
{
    public class AddProductViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public IFormFile[] UploadedFiles { get; set; }
        public string SelectedCategoryName { get; set; }
        public List<CategoryViewModel> Categories { get; set; }


    }
}
