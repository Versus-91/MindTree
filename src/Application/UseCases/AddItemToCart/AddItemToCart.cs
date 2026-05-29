using Application.Interfaces.Data;
using Application.Interfaces.UseCases;
using Domain.Entities;
namespace Application.UseCases.AddItemToCart;

public class AddItemToCart(ICartRepository _cart, IProductRepository _product) : IAddItemToCart
{
    public async Task AddItemToCartAsync(AddItemToCartInput input)
    {
        var product = await _product.GetAsync(input.ProductId);
        if (product == null)
        {
            return;
        }
        var cart = await _cart.GetByCustomerIdAsync(input.CustomerId) ?? new Cart(input.CustomerId);
        cart.AddItem(product.Id,product.Name,product.Price,input.Quantity);
        await _cart.SaveAsync(cart);
    }
}
