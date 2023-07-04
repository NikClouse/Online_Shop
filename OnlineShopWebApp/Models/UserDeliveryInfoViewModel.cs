using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
	public class UserDeliveryInfoViewModel
	{
		[Required(ErrorMessage = "Не указано ФИО")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Не указан адрес")]
		public string Address { get; set; }

		[Required(ErrorMessage = "Не указан телефон")]
		public string Phone { get; set; }


	}
}