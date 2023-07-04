
namespace OnlineShop.Db
{
	public interface ICartRepozitory
	{
		void Add(Product product, string userId);
		void Clear(string userId);
		void Remove(Product product, string userId);
		Cart TryGetById(string userId);


	}
}