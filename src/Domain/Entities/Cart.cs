using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Cart(Guid customerId)
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Guid CustomerId { get; } = customerId;

        public IReadOnlyCollection<CartItem> Items =>
             _items.AsReadOnly();

        private readonly List<CartItem> _items = new();

        public void AddItem(Guid productId, string productName, decimal
                            productPrice, int quantity)
        {
            var existingItem = _items.SingleOrDefault(i => i.ProductId ==
                                                      productId);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                _items.Add(new CartItem(productId, productName,
                           productPrice, quantity));
            }
        }
    }
}
