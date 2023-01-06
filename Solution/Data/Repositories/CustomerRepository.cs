using Data.Data;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly TradeMarketDbContext context;

        public CustomerRepository(TradeMarketDbContext context)
        {
            this.context = context;
        }

        public Task AddAsync(Customer entity)
        {
            context.Entry(entity).State = EntityState.Added;
            context.SaveChanges();
            return Task.CompletedTask;
        }

        public void Delete(Customer entity)
        {
            context.Entry(entity).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public Task DeleteByIdAsync(int id)
        {
            var customer = new Customer() { Id = id };
            context.Entry(customer).State = EntityState.Deleted;
            context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Customer>> GetAllAsync()
        {
            return Task.FromResult(context.Customers.AsEnumerable());
        }

        public Task<IEnumerable<Customer>> GetAllWithDetailsAsync()
        {
            throw new NotImplementedException();
            
        }

        public Task<Customer> GetByIdAsync(int id)
        {
            return Task.FromResult(context.Customers.Find(id));
        }

        public Task<Customer> GetByIdWithDetailsAsync(int id)
        {
           throw null;
        }

        public void Update(Customer entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
