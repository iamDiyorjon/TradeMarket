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
    public class ReceiptRepository : IReceiptRepository
    {
        private readonly TradeMarketDbContext context;
        public ReceiptRepository(TradeMarketDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Receipt entity)
        {
            context.Add(entity);
           await context.SaveChangesAsync();     
        }

        public void Delete(Receipt entity)
        {
            context.Remove(entity);
        }

        public Task DeleteByIdAsync(int id)
        {
            var deleted = context.Receipts.Find(id);
            context.Remove(deleted);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Receipt>> GetAllAsync()=>
            Task.FromResult(context.Receipts.AsEnumerable());

        public  Task<IEnumerable<Receipt>> GetAllWithDetailsAsync()
        {
            var result=context.Receipts
                .Include(cu=>cu.Customer)
                .Include(rd=>rd.ReceiptDetails)
                .ThenInclude(p=>p.Product)
                .ThenInclude(c=>c.Category)
                .AsEnumerable();
            return Task.FromResult(result);
        }

        public Task<Receipt> GetByIdAsync(int id)=>
            Task.FromResult(context.Receipts.Find(id));
        
        public async Task<Receipt> GetByIdWithDetailsAsync(int id)
        {
            return await context.Receipts
                .Include(receipt => receipt.Customer)
                .Include(receipt => receipt.ReceiptDetails)
                .ThenInclude(receiptDetails => receiptDetails.Product)
                .ThenInclude(product => product.Category)
                .FirstOrDefaultAsync(receipt => receipt.Id == id);
        }

        public void Update(Receipt entity) =>
            context.Update(entity);
    }
}
