using AGI.Morn.Application.Common.Interfaces;
using AGI.Morn.Application.Common.Models;
using AGI.Morn.Application.Common.Specifications;
using AGI.Morn.Application.UseCases.ProudctCase.DTO;
using AGI.Morn.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AGI.Morn.Application.UseCases.ProudctCase.Queries
{
    public record GetAllProudctsQuery : IRequest<DataResponse<IEnumerable<ProudctDto>>>;
    public class GetAllProudctHandeller : IRequestHandler<GetAllProudctsQuery, DataResponse<IEnumerable<ProudctDto>>>
    {
        private readonly IunitOfWork _iunitOfWork;
        private readonly IMapper _mapper;
        public GetAllProudctHandeller(IunitOfWork iunitOfWork ,IMapper mapper)
        {
            _iunitOfWork = iunitOfWork;
            _mapper = mapper;
        }
        public async Task<DataResponse<IEnumerable<ProudctDto>>> Handle(GetAllProudctsQuery request, CancellationToken cancellationToken)
        {
            ISpecifications<Product> specifications = new Specifications<Product>();
            specifications.Includes.Add(x=>x.ProductPrand);
            specifications.Includes.Add(x=>x.productType);
            var query = _iunitOfWork.ProductsRepository.GetList(specifications);
            var data = _mapper.Map<IEnumerable<Product>, IEnumerable<ProudctDto> >(query);
            return new DataResponse<IEnumerable<ProudctDto>>
            {
                StatusCode = HttpStatusCode.OK,
                ResponseData = data
            };
        }
    }
}
