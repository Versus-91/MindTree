using Application.Interfaces.Data;
using Application.UseCases.AddItemToCart;
using Domain.Entities;
using NSubstitute;

namespace Application.UnitTests
{
    public class AddItemsToCartTests
    {
        [Fact]
        public async Task AddItemToCartAsync_ValidInput_AddsItemToCart()
        {
            // Arrange
            var shoppingCartRepository = Substitute.For<ICartRepository>();
            var productRepository = Substitute.For<IProductRepository>();
            var userId = Guid.NewGuid();
            var shoppingCart = new Cart(userId);
            var product = new Product("Test Product", 10.00m,50,"");
            shoppingCartRepository.GetByCustomerIdAsync(userId).Returns(shoppingCart);
            productRepository.GetAsync(product.Id).Returns(product);
            var useCase = new AddItemToCart(shoppingCartRepository, productRepository);
            // Act
            _ = useCase.AddItemToCartAsync(new AddItemToCartInput(userId,
                                           product.Id, 1));
            // Assert
            await productRepository.Received(1).GetAsync(product.Id);
            await shoppingCartRepository.Received(1).GetByCustomerIdAsync(userId);
            await shoppingCartRepository.Received(1).SaveAsync(shoppingCart);
        }
    }
}
