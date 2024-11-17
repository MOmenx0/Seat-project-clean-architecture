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

namespace AGI.Morn.Application.UseCases.proudctTypeCases.Queries
{
    public record getAllTypesQueires : IRequest<DataResponse<IEnumerable<productTypes>>>;
    public class GetAlllTypescsHandeler : IRequestHandler<getAllTypesQueires, DataResponse<IEnumerable<productTypes>>>
    {
        private readonly IunitOfWork _unitOfWork;
        public GetAlllTypescsHandeler(IunitOfWork iunitOfWork) 
        {
            _unitOfWork = iunitOfWork;
        }
        public async Task<DataResponse<IEnumerable<productTypes>>> Handle(getAllTypesQueires request, CancellationToken cancellationToken)
        {
            var data = _unitOfWork.TypeRepositories.GetAll();

            return new DataResponse<IEnumerable<productTypes>>
            {
                StatusCode = HttpStatusCode.OK,
                ResponseData = data
            };
        }
    }
}
