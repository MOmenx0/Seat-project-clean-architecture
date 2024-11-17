using AGI.Morn.Application.UseCases.ProductPrandCases.Commands;
using AGI.Morn.Application.UseCases.ProudctCase.Command;
using AGI.Morn.Application.UseCases.ProudctCase.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGI.Morn.Application.Common.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<Product, ProudctDto>()
             .ForMember(x => x.ProductPrand, c => c.MapFrom(c => c.ProductPrand.Name))
             .ForMember(x => x.productType, j => j.MapFrom(c => c.productType.Name));

            CreateMap<CreateProudctQueriy, Product>()
            .ForMember(dest => dest.ProudctPrandId, opt => opt.MapFrom(src => src.ProductBrandId)) 
            .ForMember(dest => dest.ProductTypeId, opt => opt.MapFrom(src => src.ProductTypeId));

            CreateMap<updateProudctQuery, Product>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(dest => dest.ProudctPrandId, opt => opt.MapFrom(src => src.productTypeId))
                .ForMember(dest => dest.ProductTypeId, opt => opt.MapFrom(src => src.productTypeId));

            CreateMap<productPrandCommand, productPrand>();

        }
    }
}
