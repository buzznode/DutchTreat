using DutchTreat.Data.Entities;
using System.Collections.Generic;

namespace DutchTreat.Data
{
	public interface IDutchRepository
	{
		// Products
		IEnumerable<Product> GetAllProducts();
		IEnumerable<Product> GetProductsByCategory(string category);

		// Orders
		IEnumerable<Order> GetAllOrders(bool includeItems);
		IEnumerable<Order> GetAllOrdersByUser(string username, bool includeItems);
		Order GetOrderById(string username, int id);

		// Entiity Maniupulation
		bool SaveAll();
		bool SaveChanges();
		void AddEntity(object model);
	}
}