using AGI.Morn.Application.Common.Helper;
using AGI.Morn.Application.Common.Interfaces;
using AGI.Morn.Application.Common.Models;
using AGI.Morn.Application.Common.Specifications;
using AGI.Morn.Application.UseCases.ProudctCase.DTO;
using AGI.Morn.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGI.Morn.Application.UseCases.ProudctCase.Queries
{
    public record GetProudctByIdQuery : IRequest<DataResponse<ProudctDto>>
    {
        public int Id { get; init; }

    }
    public class GetProductByIdQuereyHandeler : IRequestHandler<GetProudctByIdQuery,DataResponse<ProudctDto>>
    {
        private readonly IunitOfWork _iunitOfWork;
        private readonly IMapper _Mapper;
        public GetProductByIdQuereyHandeler(IunitOfWork iunitOfWork , IMapper _mappingProfiles)
        {
            _iunitOfWork = iunitOfWork;
            _Mapper = _mappingProfiles;

        }

        public async Task<DataResponse<ProudctDto>> Handle(GetProudctByIdQuery request, CancellationToken cancellationToken)
        {
            ISpecifications<Product> specifications = new Specifications<Product>();
            specifications.Cretiria = x => x.Id == request.Id;
            specifications.Includes.Add(x => x.ProductPrand);
            specifications.Includes.Add(x => x.productType);
            var Proudct = await _iunitOfWork.ProductsRepository.GetOneAsync(specifications);

            if (Proudct == null)
            {
                return new DataResponse<ProudctDto>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    ResponseData = null,
                    ResponseMessage = "Product not found"
                };
            }

            var data = _Mapper.Map<Product,ProudctDto>(Proudct);

            return new DataResponse<ProudctDto>
            {
                StatusCode = HttpStatusCode.OK,
                ResponseData = data,
            };
        }
    }
}
