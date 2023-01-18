using AutoMapper;
using Business.Models;
using Data.Entities;
using System.Linq;

namespace Business
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Receipt, ReceiptModel>()
                .ForMember(rm => rm.ReceiptDetailsIds, r => r.MapFrom(x => x.ReceiptDetails
                .Select(rd => rd.Id)))
                .ReverseMap();

            CreateMap<Product, ProductModel>()
                 .ForMember(pm => pm.ReceiptDetails, r => r.MapFrom(x => x.ReceiptDetails
                 .Select(pm => pm.Id)))
                 .ReverseMap();

            CreateMap<ReceiptDetail, ReceiptDetailModel>()
                  .ReverseMap();             

            CreateMap<Customer, CustomerModel>()
                .ForMember(cm => cm.Name, p => p.MapFrom(x => x.Person.Name))
                .ForMember(cm => cm.Surname, c => c.MapFrom(x => x.Person.Surname))
                .ForMember(cm => cm.BirthDate, c => c.MapFrom(x => x.Person.BirthDate))
                .ForMember(cm => cm.ReceiptsId, c => c.MapFrom(x => x.Receipts
                .Select(pm => pm.Id)))
                .ReverseMap();

            CreateMap<ProductCategory, ProductCategoryModel>()
                .ForMember(pc => pc, p => p
                .MapFrom(x => x))
                .ReverseMap();
        }
    }
}