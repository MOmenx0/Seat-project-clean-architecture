using AGI.Morn.Application.Common.Interfaces;
using AGI.Morn.Application.Common.Models;
using AGI.Morn.Application.Common.Specifications;
using AGI.Morn.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AGI.Morn.Application.UseCases.TestsCases.Queries
{
    public record GetOneQuery : IRequest<DataResponse<Tests>>
    {
        public int Id { get; init; }
    }
    public class GetOneQueryHandler : IRequestHandler<GetOneQuery, DataResponse<Tests>>
    {
        private readonly IunitOfWork _iunitOfWork; 
        public GetOneQueryHandler(IunitOfWork iunitOfWork)
        {
            _iunitOfWork = iunitOfWork;
        }

        public async Task<DataResponse<Tests>> Handle(GetOneQuery request, CancellationToken cancellationToken)
        {
            ISpecifications<Tests> specifications = new Specifications<Tests>();
            specifications.Cretiria = x => x.Id == request.Id;
            var data = _iunitOfWork.TestRepository.GetOne(specifications);
            return new DataResponse<Tests>
            {
                StatusCode = HttpStatusCode.OK,
                ResponseData = data
            };
        }
    }
}
