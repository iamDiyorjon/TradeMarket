using AutoMapper;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TradeMarket.Tests.BusinessTests
{
    internal class ReceiptService :IReceiptService
    {
        private IUnitOfWork @object;
        private IMapper mapper;

        public ReceiptService(IUnitOfWork @object, IMapper mapper)
        {
            this.@object = @object;
            this.mapper = mapper;
        }

        public Task AddAsync(ReceiptModel model)
        {
            throw new NotImplementedException();
        }

        public Task AddProductAsync(int productId, int receiptId, int quantity)
        {
            throw new NotImplementedException();
        }

        public Task CheckOutAsync(int receiptId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int modelId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ReceiptModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ReceiptModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ReceiptDetailModel>> GetReceiptDetailsAsync(int receiptId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ReceiptModel>> GetReceiptsByPeriodAsync(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public Task RemoveProductAsync(int productId, int receiptId, int quantity)
        {
            throw new NotImplementedException();
        }

        public Task<decimal> ToPayAsync(int receiptId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ReceiptModel model)
        {
            throw new NotImplementedException();
        }
    }
}