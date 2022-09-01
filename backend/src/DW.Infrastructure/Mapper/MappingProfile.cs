using AutoMapper;
using DW.Domain.DTOs;
using DW.Domain.Entities;

namespace DW.Infrastructure.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<CustomerDto, Customer>().ReverseMap();
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<Invoice, InvoiceDto>()
                .ForMember(x => x.Num, x => x.MapFrom(src => src.Num.ToString().PadLeft(6, '0')));
            CreateMap<InvoiceDto, Invoice>();
            CreateMap<InvoiceDetailDto, InvoiceDetail>().ReverseMap();
        }
    }
}
