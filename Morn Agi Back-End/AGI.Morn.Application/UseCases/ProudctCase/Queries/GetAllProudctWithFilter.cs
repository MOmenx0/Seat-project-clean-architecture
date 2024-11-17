using AGI.Morn.Application.Common.Interfaces;
using AGI.Morn.Application.Common.Models;
using AGI.Morn.Application.Common.Specifications;
using AGI.Morn.Application.UseCases.ProudctCase.DTO;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGI.Morn.Application.UseCases.ProudctCase.Queries
{
    public record getAllProudctFilteredQuery : IRequest<DataResponse<PaginatedList<ProudctDto>>>
    {
       public ProductSpecPrams prams { get; init; }   
    }
    public class GetAllProudctWithFilter : IRequestHandler<getAllProudctFilteredQuery, DataResponse<PaginatedList<ProudctDto>>>
    {
        private readonly IunitOfWork _iunitOfWork;
        private readonly IMapper _mapper;

        public GetAllProudctWithFilter(IunitOfWork iunitOfWork, IMapper mapper)
        {
            _iunitOfWork = iunitOfWork;
            _mapper = mapper;
        }

        public async Task<DataResponse<PaginatedList<ProudctDto>>> Handle( getAllProudctFilteredQuery request, CancellationToken cancellationToken)
        {
            ISpecifications<Product> Spesc = new ProudctWithTypeAndPrandsSpecifications(request.prams);
            var Products = _iunitOfWork.ProductsRepository.GetList(Spesc);
            var data = _mapper.Map<IEnumerable<Product>, IEnumerable<ProudctDto>>(Products);
            return new DataResponse<PaginatedList<ProudctDto>>
            {
                StatusCode = HttpStatusCode.OK,
                ResponseData = new PaginatedList<ProudctDto>(data.ToList(), data.Count(), request.prams.PageIndex, request.prams.pageSize),
            };
        }
    }
}
