using Data.Data;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly TradeMarketDbContext context;

        public ProductRepository(TradeMarketDbContext context)
        {
            this.context = context;
        }

        public Task AddAsync(Product entity)
        {
            context.Add(entity);
            return Task.CompletedTask;
        }

        public void Delete(Product entity)
        {
            context.Remove(entity);
        }

        public Task DeleteByIdAsync(int id) =>
            Task.FromResult(context.Remove(context.Products.Find(id)));

        public Task<IEnumerable<Product>> GetAllAsync()=>
            Task.FromResult(context.Products.AsEnumerable());

        public Task<IEnumerable<Product>> GetAllWithDetailsAsync()=>
            Task.FromResult(context.Products
                .Include(pro=>pro.Category)
                .Include(pro=>pro.ReceiptDetails)
                .AsEnumerable());

        public Task<Product> GetByIdAsync(int id) =>
            Task.FromResult(context.Products.Find(id));

        public Task<Product> GetByIdWithDetailsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            context.Update(entity);
            context.SaveChanges();
        }
    }
}
