using Application.UseCases.AddItemToCart;

namespace Application.Interfaces.UseCases
{
    public interface IAddItemToCart
    {
        Task AddItemToCartAsync(AddItemToCartInput input);

    }
}
