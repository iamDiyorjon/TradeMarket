using AutoMapper;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TradeMarket.Tests.BusinessTests
{
    internal class ProductService :IProductService
    {
        private IUnitOfWork @object;
        private IMapper mapper;

        public ProductService(IUnitOfWork @object, IMapper mapper)
        {
            this.@object = @object;
            this.mapper = mapper;
        }

        public Task AddAsync(ProductModel model)
        {
            throw new System.NotImplementedException();
        }

        public Task AddCategoryAsync(ProductCategoryModel categoryModel)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(int modelId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<ProductModel>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<ProductCategoryModel>> GetAllProductCategoriesAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<ProductModel>> GetByFilterAsync(FilterSearchModel filterSearch)
        {
            throw new System.NotImplementedException();
        }

        public Task<ProductModel> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveCategoryAsync(int categoryId)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(ProductModel model)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateCategoryAsync(ProductCategoryModel categoryModel)
        {
            throw new System.NotImplementedException();
        }
    }
}