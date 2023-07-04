using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
	public class Register
	{

		[Required(ErrorMessage = "Введите Имя!")]
		[StringLength(22, MinimumLength = 2, ErrorMessage = "Имя дольжно содержить от 2 до 22 символа!")]
		public string UserName { get; set; }

		[Required(ErrorMessage = "Введите номер телфона!")]

		public string Phone { get; set; }


		[Required(ErrorMessage = "Не указан email")]
		[EmailAddress(ErrorMessage = "Введите валидный email")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Введите парол!")]
		public string Password { get; set; }

		[Required(ErrorMessage = "Введите повторный парол!")]
		[Compare("Password", ErrorMessage = "Парол не совпаддают!")]
		public string ConfirmPassword { get; set; }
		public string ReturnUrl { get; set; }


	}
}
