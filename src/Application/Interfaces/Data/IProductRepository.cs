using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Data
{
    public interface IProductRepository
    {
        Task<Product> GetAsync(Guid id);
        Task UpdateAsync(Product product);
    }
}
