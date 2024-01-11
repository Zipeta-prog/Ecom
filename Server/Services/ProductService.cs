using Server.Models;
using System.Collections.Immutable;

namespace Server.Services
{
	public static class ProductService
	{
		public static List<Product> Products = new List<Product>()
	{
		new Product()
		{
			Id = Guid.NewGuid(),
			Name = "Rich Dad Poor Dad",
			Description = "A book on financial management.",
			Price = 70
			
		},
		new Product()
		{
			Id = Guid.NewGuid(),
			Name = "Atomic Habits",
			Description = "A book on changing from bad to good habits over time.",
			Price = 70
		},
		new Product()
		{
			Id = Guid.NewGuid(),
			Name = "The Lean Startup",
			Description = "A book that helps you understand the building process of a startup journey.",
			Price = 100
		}
	});
	}
}
