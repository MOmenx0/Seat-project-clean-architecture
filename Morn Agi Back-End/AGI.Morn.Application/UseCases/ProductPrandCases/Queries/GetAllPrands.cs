using AGI.Morn.Application.Common.Interfaces;
using AGI.Morn.Application.Common.Models;
using AGI.Morn.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AGI.Morn.Application.UseCases.ProductPrandCases.Queries
{
    public record GetAllPrandsQueriey :IRequest<DataResponse<IEnumerable<productPrand>>>;
    public class GetAllPrands : IRequestHandler<GetAllPrandsQueriey, DataResponse<IEnumerable<productPrand>>>
    {
        private readonly IunitOfWork _iunitOfWork;
        public GetAllPrands(IunitOfWork iunitOfWork) {
            _iunitOfWork = iunitOfWork;
        }
        public async Task<DataResponse<IEnumerable<productPrand>>> Handle(GetAllPrandsQueriey request, CancellationToken cancellationToken)
        {
            var data = _iunitOfWork.PrandsRepository.GetAll();

            return new DataResponse<IEnumerable<productPrand>>
            {
                StatusCode = HttpStatusCode.OK,
                ResponseData = data
            };
        }
    }
}
