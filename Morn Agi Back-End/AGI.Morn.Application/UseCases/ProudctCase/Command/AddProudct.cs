using AGI.Morn.Application.Common.Interfaces;
using AGI.Morn.Application.Common.Models;
using AGI.Morn.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGI.Morn.Application.UseCases.ProudctCase.Command
{
    public record CreateProudctQueriy : IRequest<DataResponse<int>>
    {
        public string Name { get; init; }
        public string Description { get; init; }
        public decimal Price { get; init; }
        public string PictureUrl { get; init; }
        public int ProductTypeId { get; init; }
        public int ProductBrandId { get; init; }
    }

    public class AddProudctHandeller : IRequestHandler<CreateProudctQueriy,DataResponse<int>>
    {
        private readonly IunitOfWork _iunitOfWork;
        private readonly IMapper _mapper;
        public AddProudctHandeller(IunitOfWork iunitOfWork , IMapper mapper)
        {
            _iunitOfWork = iunitOfWork;
            _mapper = mapper;
        }   

        public async Task<DataResponse<int>> Handle(CreateProudctQueriy request, CancellationToken cancellationToken)
        {
            var NewProudct  = _mapper.Map<Product>(request);


            var data =  _iunitOfWork.ProductsRepository.Add(NewProudct);
            _iunitOfWork.SaveChanges();
            return new DataResponse<int>
            {
                StatusCode = HttpStatusCode.OK,
                ResponseData = data.Id
            };


        }
    }
}
