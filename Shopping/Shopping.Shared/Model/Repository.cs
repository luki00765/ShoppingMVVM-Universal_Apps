using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shopping.Model
{
	public class Repository
	{
		public static IEnumerable<Product> GetProducts()
		{
			var products = new List<Product>
			{
				new Product {Id = 1, Name = "Apple", Price = 2.50m},
				new Product { Id = 2, Name = "Orange", Price = 3.00m},
				new Product { Id = 3, Name = "Banana", Price = 3.50m},
				new Product { Id = 4, Name = "Watermelon", Price = 7.50m},
			};
			return products;
		}

		public static IEnumerable<ShoppingCart> GetShoppingCarts()
		{
			var shoppingCarts = new List<ShoppingCart>
			{
				new ShoppingCart { Id = 1, Date = DateTime.Now.AddDays(-2), 
					Products = new List<Product> {GetProduct(1), GetProduct(2)},
				},

				new ShoppingCart
				{
					Id = 2, Date = DateTime.Now.AddDays(-5), 
					Products = GetProducts(),
				},

				new ShoppingCart
				{
					Id = 3, Date = DateTime.Now.AddDays(-1),
					Products = new List<Product> { GetProduct(4), GetProduct(2), GetProduct(3)}
				}
			};
			return shoppingCarts;
		}

		public static Product GetProduct(int id)
		{
			return GetProducts().FirstOrDefault(x => x.Id == id);
		}

		public static ShoppingCart GetShoppingCart(int id)
		{
			return GetShoppingCarts().FirstOrDefault(x => x.Id == id);
		}
	}
}
