using AutoMapper;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TradeMarket.Tests.BusinessTests
{
    internal class CustomerService :ICustomerService
    {
        private IUnitOfWork @object;
        private IMapper mapper;

        public CustomerService(IUnitOfWork @object, IMapper mapper)
        {
            this.@object = @object;
            this.mapper = mapper;
        }

        public Task AddAsync(CustomerModel model)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(int modelId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<CustomerModel>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<CustomerModel> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();

        }

        public Task<IEnumerable<CustomerModel>> GetCustomersByProductIdAsync(int productId)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(CustomerModel model)
        {
            throw new System.NotImplementedException();
        }
    }
}