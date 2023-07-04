using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
	public class EditProductViewModel
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Cost { get; set; }
		public List<string> ImagesPaths { get; set; }
		public IFormFile[] UploadedFiles { get; set; }
	}
}
