using Server.Models;


namespace Server.Services
{
	public class CartService
	{
		//stores products selected by user
		public List<Product> SelectedItems { get; set; } = new();
		//method to add product to cart
		public void AddProductToCart(Guid productId)
		{
			var product = ProductService.Products.First(p => p.Id == productId);
			if (SelectedItems.Contains(product) is false)
			{
				SelectedItems.Add(product);
			}
		}

	}
}
