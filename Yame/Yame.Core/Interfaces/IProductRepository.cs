using System;
using System.Collections.Generic;
using Yame.Models.Domain;

namespace Yame.Core
{
    public interface IProductRepository
    {
        IList<Product> GetAll();
        Product GetById(Guid id);
        void Update(Product product);
        void Add(Product product);
        void Delete(Guid id);
    }
}
