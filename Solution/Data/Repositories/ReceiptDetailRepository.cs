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
    public class ReceiptDetailRepository : IReceiptDetailRepository
    {
        private readonly TradeMarketDbContext context;

        public ReceiptDetailRepository(TradeMarketDbContext context)
        {
            this.context = context;
        }

        public Task AddAsync(ReceiptDetail entity)
        {
            context.Add(entity);
            return Task.CompletedTask;
        }

        public void Delete(ReceiptDetail entity)
        {
            context.Remove(entity);
            context.SaveChanges();
        }

        public Task DeleteByIdAsync(int id)
        {
            context.Remove(context.ReceiptsDetails.Find(id));
            return Task.CompletedTask;
        }

        public Task<IEnumerable<ReceiptDetail>> GetAllAsync() =>
            Task.FromResult(context.ReceiptsDetails.AsEnumerable());

        public Task<IEnumerable<ReceiptDetail>> GetAllWithDetailsAsync()
        {
            var result=context.ReceiptsDetails
                .Include(re=>re.Receipt)
                .Include(re=>re.Product).Include(re=>re.Product.Category).AsEnumerable();

            return Task.FromResult(result);
        }

        public Task<ReceiptDetail> GetByIdAsync(int id) =>
            Task.FromResult(context.ReceiptsDetails.Find(id));

        public void Update(ReceiptDetail entity)
        {
            context.Update(entity);
            context.SaveChanges();
        }
    }
}
