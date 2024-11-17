using AGI.Morn.Application.Common.Interfaces;
using AGI.Morn.Application.Common.Models;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGI.Morn.Application.UseCases.ProductPrandCases.Commands
{
    public record productPrandCommand:IRequest<DataResponse<int>>
    {
        public string Name { get; init; }
    }
    public class CreateProductPrand : IRequestHandler<productPrandCommand, DataResponse<int>>
    {
        private readonly IunitOfWork _iunitOfWork;
        private readonly IMapper _mapper;
        public CreateProductPrand(IunitOfWork iunitOfWork, IMapper mapper)
        {
            _iunitOfWork = iunitOfWork;
            _mapper = mapper;
        }
        public async Task<DataResponse<int>> Handle(productPrandCommand request, CancellationToken cancellationToken)
        {

            var data = new productPrand();
            data = _mapper.Map<productPrand>(request);
            _iunitOfWork.PrandsRepository.Add(data);
            _iunitOfWork.SaveChanges();
            return new DataResponse<int>
            {
                StatusCode=HttpStatusCode.OK,
                ResponseData =data.Id 
            };
        }
    }
}
