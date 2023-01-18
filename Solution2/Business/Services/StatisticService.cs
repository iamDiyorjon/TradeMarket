using AutoMapper;
using Data.Interfaces;

namespace TradeMarket.Tests.BusinessTests
{
    public class StatisticService
    {
        private IUnitOfWork @object;
        private IMapper mapper;

        public StatisticService(IUnitOfWork @object, IMapper mapper)
        {
            this.@object = @object;
            this.mapper = mapper;
        }
    }
}