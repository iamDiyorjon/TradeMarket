using Data.Interfaces;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Data.Data
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly TradeMarketDbContext context;
        public UnitOfWork(TradeMarketDbContext context)
        {
            this.context = context;
        }

        public ICustomerRepository CustomerRepository => throw new NotImplementedException();

        public IPersonRepository PersonRepository => throw new NotImplementedException();

        public IProductRepository ProductRepository => throw new NotImplementedException();

        public IProductCategoryRepository ProductCategoryRepository => throw new NotImplementedException();

        public IReceiptRepository ReceiptRepository => throw new NotImplementedException();

        public IReceiptDetailRepository ReceiptDetailRepository => throw new NotImplementedException();

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
    //TODO: create class UnitOfWork
}
