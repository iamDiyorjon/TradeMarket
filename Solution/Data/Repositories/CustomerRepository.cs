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

        public CustomerRepository(TradeMarketDbContext context)=>
            this.context = context;
        

        public async Task AddAsync(Customer entity)
        {
            context.Entry(entity).State = EntityState.Added;
           await context.SaveChangesAsync();
           
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

        public Task<IEnumerable<Customer>> GetAllAsync()=>
            Task.FromResult(context.Customers.AsEnumerable());

        public async Task<IEnumerable<Customer>> GetAllWithDetailsAsync()=>
         await   Task.FromResult(context.Customers
                .Include(per => per.Person)
                .Include(re => re.Receipts)
                .ThenInclude(de => de.ReceiptDetails)
                .AsEnumerable());

        public async Task<Customer> GetByIdAsync(int id)=>
           await  Task.FromResult(context.Customers.Find(id));

        public  async Task<Customer> GetByIdWithDetailsAsync(int id)=>
          await  Task.FromResult(context.Customers.Include(per => per.Person)
                .Include(re => re.Receipts)
                .ThenInclude(de => de.ReceiptDetails)
                .Where(de => de.Id == id)
                .FirstOrDefault());

        public void Update(Customer entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
