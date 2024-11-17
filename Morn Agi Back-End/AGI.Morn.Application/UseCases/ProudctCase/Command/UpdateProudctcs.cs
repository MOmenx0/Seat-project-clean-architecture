using AGI.Morn.Application.Common.Interfaces;
using AGI.Morn.Application.Common.Models;
using AGI.Morn.Application.UseCases.ProudctCase.DTO;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGI.Morn.Application.UseCases.ProudctCase.Command
{
    public record updateProudctQuery : IRequest<DataResponse<int>>
    {
        public int Id { get; init; }
        public string Name { set; get; }
        public string Description { set; get; }

        public decimal Price { set; get; }

        public string PictureUrl { set; get; }

        public int productTypeId { set; get; }
        public int ProductPrandId { set; get; }

    }
    public class UpdateProudct : IRequestHandler<updateProudctQuery,DataResponse<int>>
    {
        private readonly IunitOfWork _iunitOfWork;
        private readonly IMapper _mapper;
        public UpdateProudct (IunitOfWork iunitOfWork ,IMapper mapper)
        {
            _iunitOfWork = iunitOfWork;
            _mapper = mapper;
        }
        public async Task<DataResponse<int>> Handle(updateProudctQuery request, CancellationToken cancellationToken)
        {
            var proudct = _iunitOfWork.ProductsRepository.GetById(request.Id);
            _mapper.Map(request, proudct);

            _iunitOfWork.ProductsRepository.Update(proudct);
            _iunitOfWork.SaveChanges();

            return new DataResponse<int>()
            {
                StatusCode = HttpStatusCode.OK,
                ResponseData = proudct.Id
            };
        }
    }
}
