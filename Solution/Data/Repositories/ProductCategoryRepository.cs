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
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly TradeMarketDbContext context;

        public ProductCategoryRepository(TradeMarketDbContext context)=>
            this.context = context;

        public Task AddAsync(ProductCategory entity)
        {
           context.Entry(entity).State=EntityState.Added;
           context.SaveChanges();
           return Task.CompletedTask;
        }

        public void Delete(ProductCategory entity)
        {
            context.Entry(entity).State= EntityState.Deleted;
        }

        public Task DeleteByIdAsync(int id)
        {
            var deled = context.ProductCategories.Find(id);
            context.Entry(deled).State= EntityState.Deleted;
            context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task<IEnumerable<ProductCategory>> GetAllAsync()=>
            Task.FromResult(context.ProductCategories.AsEnumerable());
        

        public Task<ProductCategory> GetByIdAsync(int id)=>
            Task.FromResult(context.ProductCategories.Find(id));


        public void Update(ProductCategory entity)
        {
            context.Update(entity);
            context.SaveChanges();
        }
    }
}
