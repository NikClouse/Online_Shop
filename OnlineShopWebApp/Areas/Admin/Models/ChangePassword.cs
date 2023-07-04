using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
	public class ChangePassword
	{
		public string UserName { get; set; }


		[Required(ErrorMessage = "Введите парол!")]
		public string Password { get; set; }

		[Required(ErrorMessage = "Введите повторный парол!")]
		[Compare("Password", ErrorMessage = "Парол не совпаддают!")]
		public string ConfirmPassword { get; set; }

	}
}
